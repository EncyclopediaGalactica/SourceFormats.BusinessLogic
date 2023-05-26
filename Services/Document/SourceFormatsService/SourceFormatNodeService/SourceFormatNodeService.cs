namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using FluentValidation;
using Interfaces.SourceFormatNode;
using Mappers.Interfaces;
using Microsoft.Extensions.Logging;
using SourceFormatsCacheService.Interfaces;
using SourceFormatsRepository.Interfaces;
using Utils.GuardsService.Interfaces;

public partial class SourceFormatNodeService : ISourceFormatNodeService
{
    private const string SourceFormatNodesListKey = "SourceFormatNodesList";
    private readonly int _cacheExpiresInMinutes = 60;
    private readonly IGuardsService _guards;
    private readonly ILogger _logger;
    private readonly ISourceFormatMappers _sourceFormatMappers;
    private readonly ISourceFormatNodeCacheService _sourceFormatNodeCacheService;
    private readonly IValidator<SourceFormatNodeDto> _sourceFormatNodeDtoValidator;
    private readonly ISourceFormatNodeRepository _sourceFormatNodeRepository;

    public SourceFormatNodeService(
        IValidator<SourceFormatNodeDto> sourceFormatNodeDtoValidator,
        IGuardsService guardsService,
        ISourceFormatMappers sourceFormatMappers,
        ISourceFormatNodeRepository sourceFormatNodeRepository,
        ISourceFormatNodeCacheService sourceFormatNodeCacheService,
        ILogger<SourceFormatNodeService> logger)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatNodeDtoValidator);
        ArgumentNullException.ThrowIfNull(guardsService);
        ArgumentNullException.ThrowIfNull(sourceFormatMappers);
        ArgumentNullException.ThrowIfNull(sourceFormatNodeRepository);
        ArgumentNullException.ThrowIfNull(sourceFormatNodeCacheService);
        ArgumentNullException.ThrowIfNull(logger);

        _sourceFormatNodeDtoValidator = sourceFormatNodeDtoValidator;
        _guards = guardsService;
        _sourceFormatMappers = sourceFormatMappers;
        _sourceFormatNodeRepository = sourceFormatNodeRepository;
        _sourceFormatNodeCacheService = sourceFormatNodeCacheService;
        _logger = logger;
    }

    public async Task<SourceFormatNodeDto> GetSourceFormatNodeByIdWithChildrenAsync(long id,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<SourceFormatNodeDto> GetSourceFormatNodeByIdWithNodeTreeAsync(long id,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<SourceFormatNode>> GetSourceFormatNodesAsync(
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}