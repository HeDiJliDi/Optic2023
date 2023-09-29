namespace FSH.WebApi.Application.Catalog.Fiches;

public class FicheDto : IDto
{
    public Guid Id { get; set; }
    public string Nom { get; set; } = default!;
    public string? Prenom { get; set; }
    public string NumeroFiche { get; set; }
}