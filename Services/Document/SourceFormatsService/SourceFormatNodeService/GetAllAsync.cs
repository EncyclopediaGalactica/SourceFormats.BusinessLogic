namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using Interfaces;
using Interfaces.SourceFormatNode;
using Microsoft.Extensions.Logging;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task<List<SourceFormatNodeDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        List<SourceFormatNode> sourceFormatNodes = await _sourceFormatNodeRepository
            .GetAllAsync(cancellationToken)
            .ConfigureAwait(false);
        return _sourceFormatMappers.SourceFormatNodeMappers
            .MapSourceFormatNodesToSourceFormatNodeDtosInFlatFashion(sourceFormatNodes);
    }
}