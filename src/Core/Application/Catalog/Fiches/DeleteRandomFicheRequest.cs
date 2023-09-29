namespace FSH.WebApi.Application.Catalog.Fiches;

public class DeleteRandomFicheRequest : IRequest<string>
{
}

public class DeleteRandomFicheRequestHandler : IRequestHandler<DeleteRandomFicheRequest, string>
{
    private readonly IJobService _jobService;

    public DeleteRandomFicheRequestHandler(IJobService jobService) => _jobService = jobService;

    public Task<string> Handle(DeleteRandomFicheRequest request, CancellationToken cancellationToken)
    {
        string jobId = _jobService.Schedule<IFicheGeneratorJob>(x => x.CleanAsync(default), TimeSpan.FromSeconds(5));
        return Task.FromResult(jobId);
    }
}