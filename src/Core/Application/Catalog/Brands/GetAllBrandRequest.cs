using FSH.WebApi.Application.Catalog.Fiches;
using FSH.WebApi.Application.Common.Persistence;

namespace FSH.WebApi.Application.Catalog.Brands
{
    public class GetAllBrandsRequest : IRequest<List<BrandDto>>
    {

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllBrandsRequest(int pageNumber, int pageSize) { PageNumber = pageNumber; PageSize = pageSize; }
        // Vous pouvez ajouter des propriétés supplémentaires pour filtrer ou paginer si nécessaire.
    }

    public class GetAllBrandsRequestHandler : IRequestHandler<GetAllBrandsRequest, List<BrandDto>>
    {
        private readonly IRepository<Brand> _repository;
        private readonly IStringLocalizer _t;

        public GetAllBrandsRequestHandler(IRepository<Brand> repository, IStringLocalizer<GetAllBrandsRequestHandler> localizer)
        {
            _repository = repository;
            _t = localizer;
        }

        public async Task<List<BrandDto>> Handle(GetAllBrandsRequest request, CancellationToken cancellationToken)
        {
            // Utilisez le repository pour récupérer toutes les marques
            var allBrands = await _repository.ListAsync(); // Assurez-vous d'implémenter cette méthode dans votre repository.

            // Mappez les marques en BrandDto
            var brandDtos = allBrands.Select(brand => new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                Description = brand.Description
            }).Skip((request.PageNumber - 1) * request.PageSize)
           .Take(request.PageSize)
           .ToList();



            return brandDtos;
        }
    }


}
