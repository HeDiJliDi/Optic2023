namespace FSH.WebApi.Application.Catalog.Fiches;

public class SearchFichesRequest : PaginationFilter, IRequest<PaginationResponse<FicheDto>>
{
}

public class FichesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Fiche, FicheDto>
{
    public FichesBySearchRequestSpec(SearchFichesRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Nom, !request.HasOrderBy());
}

public class SearchFichesRequestHandler : IRequestHandler<SearchFichesRequest, PaginationResponse<FicheDto>>
{
    private readonly IReadRepository<Fiche> _repository;

    public SearchFichesRequestHandler(IReadRepository<Fiche> repository) => _repository = repository;

    public async Task<PaginationResponse<FicheDto>> Handle(SearchFichesRequest request, CancellationToken cancellationToken)
    {
        var spec = new FichesBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}