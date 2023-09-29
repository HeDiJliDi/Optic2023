namespace FSH.WebApi.Application.Catalog.Fiches;

public class CreateFicheRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreateFicheRequestValidator : CustomValidator<CreateFicheRequest>
{
    public CreateFicheRequestValidator(IReadRepository<Fiche> repository, IStringLocalizer<CreateFicheRequestValidator> T) =>
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
                .WithMessage((_, name) => T["Fiche {0} already Exists.", name]);
}

public class CreateFicheRequestHandler : IRequestHandler<CreateFicheRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Fiche> _repository;

    public CreateFicheRequestHandler(IRepositoryWithEvents<Fiche> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateFicheRequest request, CancellationToken cancellationToken)
    {
        var Fiche = new Fiche(request.Name, request.Description);

        await _repository.AddAsync(Fiche, cancellationToken);

        return Fiche.Id;
    }
}