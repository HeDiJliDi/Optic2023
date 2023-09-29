namespace FSH.WebApi.Application.Catalog.Fiches;

public class GetFicheByNumeroFicheRequest : IRequest<FicheDto>
{
    public String NumeroFiche { get; set; }
  

   
    public GetFicheByNumeroFicheRequest(String numeroFiche) => NumeroFiche = numeroFiche;

}

public class FicheByNumeroFicheSpec : Specification<Fiche, FicheDto>, ISingleResultSpecification
{
    public FicheByNumeroFicheSpec(String numeroFiche) =>
        Query.Where(p => p.NumeroFiche == numeroFiche);
}

public class GetFicheByNumeroFicheRequestHandler : IRequestHandler<GetFicheByNumeroFicheRequest, FicheDto>
{
    private readonly IRepository<Fiche> _repository;
    private readonly IStringLocalizer _t;

    public GetFicheByNumeroFicheRequestHandler(IRepository<Fiche> repository, IStringLocalizer<GetFicheByNumeroFicheRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<FicheDto> Handle(GetFicheByNumeroFicheRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<Fiche, FicheDto>)new FicheByNumeroFicheSpec(request.NumeroFiche), cancellationToken)
        ?? throw new NotFoundException(_t["Fiche {0} Not Found.", request.NumeroFiche]);
}