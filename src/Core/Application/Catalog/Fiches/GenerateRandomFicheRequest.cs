namespace FSH.WebApi.Application.Catalog.Fiches;

public class GenerateRandomFicheRequest : IRequest<string>
{
    public int NSeed { get; set; }
}

public class GenerateRandomFicheRequestHandler : IRequestHandler<GenerateRandomFicheRequest, string>
{
    private readonly IJobService _jobService;

    public GenerateRandomFicheRequestHandler(IJobService jobService) => _jobService = jobService;

    public Task<string> Handle(GenerateRandomFicheRequest request, CancellationToken cancellationToken)
    {
        string jobId = _jobService.Enqueue<IFicheGeneratorJob>(x => x.GenerateAsync(request.NSeed, default));
        return Task.FromResult(jobId);
    }
}