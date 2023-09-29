<<<<<<< HEAD
﻿
using FSH.WebApi.Application.Catalog.Brands;
using FSH.WebApi.Domain.Catalog;


=======
﻿using FSH.WebApi.Application.Catalog.Brands;
>>>>>>> c92002da726e2279104296f5a25f1c50df0df2f3

namespace FSH.WebApi.Host.Controllers.Catalog;

public class BrandsController : VersionedApiController
{
<<<<<<< HEAD

=======
>>>>>>> c92002da726e2279104296f5a25f1c50df0df2f3
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Brands)]
    [OpenApiOperation("Search brands using available filters.", "")]
    public Task<PaginationResponse<BrandDto>> SearchAsync(SearchBrandsRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Get brand details.", "")]
    public Task<BrandDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetBrandRequest(id));
    }

<<<<<<< HEAD
    [HttpPost("/pagination")]
    [MustHavePermission(FSHAction.View, FSHResource.Brands)]
    [OpenApiOperation("Get a list of all brands.", "")]
    public Task<List<BrandDto>> GetListAsync( int pageNumber, int pageSize)
    {
        return Mediator.Send(new GetAllBrandsRequest(pageNumber, pageSize));
    }

    [HttpPost]
    [AllowAnonymous]
=======
    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Brands)]
>>>>>>> c92002da726e2279104296f5a25f1c50df0df2f3
    [OpenApiOperation("Create a new brand.", "")]
    public Task<Guid> CreateAsync(CreateBrandRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Brands)]
    [OpenApiOperation("Update a brand.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateBrandRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Brands)]
    [OpenApiOperation("Delete a brand.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteBrandRequest(id));
    }

    [HttpPost("generate-random")]
    [MustHavePermission(FSHAction.Generate, FSHResource.Brands)]
    [OpenApiOperation("Generate a number of random brands.", "")]
    public Task<string> GenerateRandomAsync(GenerateRandomBrandRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpDelete("delete-random")]
    [MustHavePermission(FSHAction.Clean, FSHResource.Brands)]
    [OpenApiOperation("Delete the brands generated with the generate-random call.", "")]
    [ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Search))]
    public Task<string> DeleteRandomAsync()
    {
        return Mediator.Send(new DeleteRandomBrandRequest());
    }
}