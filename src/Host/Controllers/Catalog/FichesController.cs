using DocumentFormat.OpenXml.Wordprocessing;
using FSH.WebApi.Application.Catalog.Brands;
using FSH.WebApi.Application.Catalog.Fiches;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace FSH.WebApi.Host.Controllers.Catalog;

public class FichesController : VersionedApiController
{
    [HttpPost("search")]
    [MustHavePermission(FSHAction.Search, FSHResource.Fiches)]
    [OpenApiOperation("Search Fiches using available filters.", "")]
    public Task<PaginationResponse<FicheDto>> SearchAsync(SearchFichesRequest request)
    {
        return Mediator.Send(request);
    }
    [HttpPost("/PaginationFiche")]
    [MustHavePermission(FSHAction.View, FSHResource.Fiches)]
    [OpenApiOperation("Get a list of all Fiches.", "")]
    public Task<List<FicheDto>> GetListAsync([FromBody] int pageNumber,  int pageSize)
    {
        return Mediator.Send(new GetAllFichesRequest(pageNumber, pageSize));
    }
    [HttpPost]
    [AllowAnonymous]
    [OpenApiOperation("Create a new Fiche.", "")]
    public Task<Guid> CreateAsync(CreateFicheRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPut("{id:guid}")]
    [MustHavePermission(FSHAction.Update, FSHResource.Fiches)]
    [OpenApiOperation("Update a Fiche.", "")]
    public async Task<ActionResult<Guid>> UpdateAsync(UpdateFicheRequest request, Guid id)
    {
        return id != request.Id
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }

    [HttpDelete("{id:guid}")]
    [MustHavePermission(FSHAction.Delete, FSHResource.Fiches)]
    [OpenApiOperation("Delete a Fiche.", "")]
    public Task<Guid> DeleteAsync(Guid id)
    {
        return Mediator.Send(new DeleteFicheRequest(id));
    }
    [HttpGet("{id:guid}")]
    [MustHavePermission(FSHAction.View, FSHResource.Fiches)]
    [OpenApiOperation("Get Fiche details.", "")]
    public Task<FicheDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetFicheRequest(id));
    }
    [HttpGet("{NumeroFiche}")]
    [MustHavePermission(FSHAction.View, FSHResource.Fiches)]
    [OpenApiOperation("Get Fiche details By Numero Fiche.", "")]
    public Task<FicheDto> GetAsyncByNumeroFiche(string NumeroFiche)
    {
        return Mediator.Send(new GetFicheByNumeroFicheRequest(NumeroFiche.Replace("%2F", "/")));
    }

    [HttpPost("generate-random")]
    [MustHavePermission(FSHAction.Generate, FSHResource.Fiches)]
    [OpenApiOperation("Generate a number of random Fiches.", "")]
    public Task<string> GenerateRandomAsync(GenerateRandomFicheRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpDelete("delete-random")]
    [MustHavePermission(FSHAction.Clean, FSHResource.Fiches)]
    [OpenApiOperation("Delete the Fiches generated with the generate-random call.", "")]
    [ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Search))]
    public Task<string> DeleteRandomAsync()
    {
        return Mediator.Send(new DeleteRandomFicheRequest());
    }
}