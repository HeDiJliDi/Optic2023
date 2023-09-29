namespace FSH.WebApi.Application.Catalog.Fiches;

public class FicheByNameSpec : Specification<Fiche>, ISingleResultSpecification
{
    public FicheByNameSpec(string name) =>
        Query.Where(b => b.Nom == name);
}