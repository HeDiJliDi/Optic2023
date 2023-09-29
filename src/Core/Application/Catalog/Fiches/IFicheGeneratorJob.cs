using System.ComponentModel;

namespace FSH.WebApi.Application.Catalog.Fiches;

public interface IFicheGeneratorJob : IScopedService
{
    [DisplayName("Generate Random Fiche example job on Queue notDefault")]
    Task GenerateAsync(int nSeed, CancellationToken cancellationToken);

    [DisplayName("removes all random Fiches created example job on Queue notDefault")]
    Task CleanAsync(CancellationToken cancellationToken);
}
