namespace FSH.WebApi.Application.Catalog.Fiches;

public class GetFicheRequest : IRequest<FicheDto>
{
    public Guid Id { get; set; }

    public GetFicheRequest(Guid id) => Id = id;
    
}

public class FicheByIdSpec : Specification<Fiche, FicheDto>, ISingleResultSpecification
{
    public FicheByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetFicheRequestHandler : IRequestHandler<GetFicheRequest, FicheDto>
{
    private readonly IRepository<Fiche> _repository;
    private readonly IStringLocalizer _t;

    public GetFicheRequestHandler(IRepository<Fiche> repository, IStringLocalizer<GetFicheRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<FicheDto> Handle(GetFicheRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Fiche, FicheDto>)new FicheByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Fiche {0} Not Found.", request.Id]);
}