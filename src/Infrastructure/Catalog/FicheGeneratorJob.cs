using Ardalis.Specification;
using FSH.WebApi.Application.Catalog.Fiches;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Application.Common.Persistence;
using FSH.WebApi.Domain.Catalog;
using FSH.WebApi.Shared.Notifications;
using Hangfire;
using Hangfire.Console.Extensions;
using Hangfire.Console.Progress;
using Hangfire.Server;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.WebApi.Infrastructure.Catalog;

public class FicheGeneratorJob : IFicheGeneratorJob
{
    private readonly ILogger<FicheGeneratorJob> _logger;
    private readonly ISender _mediator;
    private readonly IReadRepository<Fiche> _repository;
    private readonly IProgressBarFactory _progressBar;
    private readonly PerformingContext _performingContext;
    private readonly INotificationSender _notifications;
    private readonly ICurrentUser _currentUser;
    private readonly IProgressBar _progress;

    public FicheGeneratorJob(
        ILogger<FicheGeneratorJob> logger,
        ISender mediator,
        IReadRepository<Fiche> repository,
        IProgressBarFactory progressBar,
        PerformingContext performingContext,
        INotificationSender notifications,
        ICurrentUser currentUser)
    {
        _logger = logger;
        _mediator = mediator;
        _repository = repository;
        _progressBar = progressBar;
        _performingContext = performingContext;
        _notifications = notifications;
        _currentUser = currentUser;
        _progress = _progressBar.Create();
    }

    private async Task NotifyAsync(string message, int progress, CancellationToken cancellationToken)
    {
        _progress.SetValue(progress);
        await _notifications.SendToUserAsync(
            new JobNotification()
            {
                JobId = _performingContext.BackgroundJob.Id,
                Message = message,
                Progress = progress
            },
            _currentUser.GetUserId().ToString(),
            cancellationToken);
    }

    [Queue("notdefault")]
    public async Task GenerateAsync(int nSeed, CancellationToken cancellationToken)
    {
        await NotifyAsync("Your job processing has started", 0, cancellationToken);

        foreach (int index in Enumerable.Range(1, nSeed))
        {
            await _mediator.Send(
                new CreateFicheRequest
                {
                    Name = $"Fiche Random - {Guid.NewGuid()}",
                    Description = "Funny description"
                },
                cancellationToken);

            await NotifyAsync("Progress: ", nSeed > 0 ? (index * 100 / nSeed) : 0, cancellationToken);
        }

        await NotifyAsync("Job successfully completed", 0, cancellationToken);
    }

    [Queue("notdefault")]
    [AutomaticRetry(Attempts = 5)]
    public async Task CleanAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Initializing Job with Id: {jobId}", _performingContext.BackgroundJob.Id);

        var items = await _repository.ListAsync(new RandomFichesSpec(), cancellationToken);

        _logger.LogInformation("Fiches Random: {FichesCount} ", items.Count.ToString());

        foreach (var item in items)
        {
            await _mediator.Send(new DeleteFicheRequest(item.Id), cancellationToken);
        }

        _logger.LogInformation("All random Fiches deleted.");
    }
}

public class RandomFichesSpec : Specification<Fiche>
{
    public RandomFichesSpec() =>
        Query.Where(b => !string.IsNullOrEmpty(b.Nom) && b.Nom.Contains("Fiche Random"));
}