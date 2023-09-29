using FSH.WebApi.Application.Catalog.Products;

namespace FSH.WebApi.Application.Catalog.Fiches;

public class DeleteFicheRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteFicheRequest(Guid id) => Id = id;
}

public class DeleteFicheRequestHandler : IRequestHandler<DeleteFicheRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Fiche> _FicheRepo;
    //private readonly IReadRepository<Product> _productRepo;
    private readonly IStringLocalizer _t;

    public DeleteFicheRequestHandler(IRepositoryWithEvents<Fiche> FicheRepo,  IStringLocalizer<DeleteFicheRequestHandler> localizer) =>
        (_FicheRepo, _t) = (FicheRepo,  localizer);

    public async Task<Guid> Handle(DeleteFicheRequest request, CancellationToken cancellationToken)
    {
        //if (await _productRepo.AnyAsync(new ProductsByFicheSpec(request.Id), cancellationToken))
        //{
        //    throw new ConflictException(_t["Fiche cannot be deleted as it's being used."]);
        //}

        var Fiche = await _FicheRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = Fiche ?? throw new NotFoundException(_t["Fiche {0} Not Found."]);

        await _FicheRepo.DeleteAsync(Fiche, cancellationToken);

        return request.Id;
    }
}