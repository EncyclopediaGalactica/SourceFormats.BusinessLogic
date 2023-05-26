namespace EncyclopediaGalactica.SourceFormats.ValidatorService;

using Entities;
using FluentValidation;

public class SourceFormatNodeValidator : AbstractValidator<SourceFormatNode>
{
    public const string Add = "Add";
    public const string Update = "Update";
    public const string Delete = "Delete";

    public SourceFormatNodeValidator()
    {
        RuleFor(notNull => notNull).NotNull();

        RuleSet(Add, () =>
        {
            RuleFor(p => p.Id).Equal(0);
            RuleFor(p => p.Name!.Trim()).NotEmpty().NotNull().NotEqual(" ");
            RuleFor(p => p.Name!.Trim().Length).GreaterThanOrEqualTo(3);
        });

        RuleSet(Update, () =>
        {
            RuleFor(p => p.Id).NotEqual(0);
            RuleFor(p => p.Name.Trim()).NotEmpty().NotNull().NotEqual(" ");
            RuleFor(p => p.Name!.Trim().Length).GreaterThanOrEqualTo(3);
        });

        RuleSet(Delete, () =>
        {
            RuleFor(r => r.Id).NotEqual(0);
            RuleFor(r => r.RootNodeId).NotEqual(0);
        });
    }
}