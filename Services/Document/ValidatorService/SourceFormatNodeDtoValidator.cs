namespace EncyclopediaGalactica.SourceFormats.ValidatorService;

using Dtos;
using FluentValidation;

public class SourceFormatNodeDtoValidator : AbstractValidator<SourceFormatNodeDto>
{
    public const string Add = "Add";
    public const string Update = "Update";

    public SourceFormatNodeDtoValidator()
    {
#pragma warning disable CS8602
        RuleSet(Add, () =>
        {
            RuleFor(p => p.Id).Equal(0);
            RuleFor(p => p.Name).NotNull();
            When(p => p.Name is not null, () =>
            {
                RuleFor(p => p.Name.Trim())
                    .NotNull()
                    .NotEmpty();
                RuleFor(p => p.Name.Length)
                    .GreaterThanOrEqualTo(3);
            });
        });

        RuleSet(Update, () =>
        {
            RuleFor(p => p.Id).GreaterThan(0);
            RuleFor(p => p.Name).NotNull();
            When(p => p.Name is not null, () =>
            {
                RuleFor(p => p.Name.Trim())
                    .NotNull()
                    .NotEmpty();
                RuleFor(p => p.Name.Length)
                    .GreaterThanOrEqualTo(3);
            });
        });
#pragma warning restore CS8602
    }
}