namespace EncyclopediaGalactica.SourceFormats.ValidatorService;

using Entities;
using FluentValidation;

public class DocumentValidator : AbstractValidator<Document>
{
    public DocumentValidator()
    {
        RuleSet(Operations.Add, () =>
        {
            RuleFor(p => p.Id).Equal(0);
            RuleFor(p => p.Name).NotNull().NotEmpty();
            RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
            RuleFor(p => p.Description).NotNull();
        });
    }
}