namespace FSH.WebApi.Application.Catalog.Fiches
{
    public class GetAllFichesRequest : IRequest<List<FicheDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllFichesRequest(int pageNumber, int pageSize) { PageNumber = pageNumber; PageSize = pageSize; }

        // Vous pouvez ajouter des propriétés supplémentaires pour filtrer ou paginer si nécessaire.
    }

    public class GetAllFichesRequestHandler : IRequestHandler<GetAllFichesRequest, List<FicheDto>>
    {
        private readonly IRepository<Fiche> _repository;
        private readonly IStringLocalizer _t;

        public GetAllFichesRequestHandler(IRepository<Fiche> repository, IStringLocalizer<GetAllFichesRequestHandler> localizer)
        {
            _repository = repository;
            _t = localizer;
        }

        public async Task<List<FicheDto>> Handle(GetAllFichesRequest request, CancellationToken cancellationToken)
        {
            // Utilisez le repository pour récupérer toutes les marques
            var allFiches = await _repository.ListAsync(); // Assurez-vous d'implémenter cette méthode dans votre repository.

            // Mappez les marques en FicheDto
            var FicheDtos = allFiches.Select(Fiche => new FicheDto
            {
               Id= Fiche.Id,
               Nom=Fiche.Nom,
               Prenom=Fiche.Prenom,
               NumeroFiche=Fiche.NumeroFiche
            }).Skip((request.PageNumber - 1) * request.PageSize)
           .Take(request.PageSize)
           .ToList();

            return FicheDtos;
        }
    }
}
