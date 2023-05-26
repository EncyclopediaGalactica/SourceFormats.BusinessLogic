namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;
using FluentValidation;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Utils.GuardsService.Interfaces;

public partial class SourceFormatNodeRepository : ISourceFormatNodeRepository
{
    private readonly DbContextOptions<SourceFormatsDbContext> _dbContextOptions;
    private readonly IGuardsService _guards;
    private readonly IValidator<SourceFormatNode> _sourceFormatNodeValidator;

    public SourceFormatNodeRepository(
        DbContextOptions<SourceFormatsDbContext> dbContextOptions,
        IValidator<SourceFormatNode> sourceFormatNodeValidator,
        IGuardsService guardsService)
    {
        _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        _sourceFormatNodeValidator = sourceFormatNodeValidator ??
                                     throw new ArgumentNullException(nameof(sourceFormatNodeValidator));
        _guards = guardsService ?? throw new ArgumentNullException(nameof(guardsService));
    }
}