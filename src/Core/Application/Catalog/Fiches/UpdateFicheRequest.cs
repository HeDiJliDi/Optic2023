namespace FSH.WebApi.Application.Catalog.Fiches;

public class UpdateFicheRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class UpdateFicheRequestValidator : CustomValidator<UpdateFicheRequest>
{
    public UpdateFicheRequestValidator(IRepository<Fiche> repository, IStringLocalizer<UpdateFicheRequestValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (Fiche, name, ct) =>
                    await repository.FirstOrDefaultAsync(new FicheByNameSpec(name), ct)
                        is not Fiche existingFiche || existingFiche.Id == Fiche.Id)
                .WithMessage((_, name) => T["Fiche {0} already Exists.", name]);
}

public class UpdateFicheRequestHandler : IRequestHandler<UpdateFicheRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Fiche> _repository;
    private readonly IStringLocalizer _t;

    public UpdateFicheRequestHandler(IRepositoryWithEvents<Fiche> repository, IStringLocalizer<UpdateFicheRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);

    public async Task<Guid> Handle(UpdateFicheRequest request, CancellationToken cancellationToken)
    {
        var Fiche = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = Fiche
        ?? throw new NotFoundException(_t["Fiche {0} Not Found.", request.Id]);

        Fiche.Update(request.Name, request.Description);

        await _repository.UpdateAsync(Fiche, cancellationToken);

        return request.Id;
    }
}