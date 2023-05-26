namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using Interfaces;
using Interfaces.SourceFormatNode;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeDto> AddChildToParentAsync(
        SourceFormatNodeDto childDto,
        SourceFormatNodeDto parentDto,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(childDto);
        ArgumentNullException.ThrowIfNull(parentDto);
        _guards.IsNotEqual(childDto.Id, 0);
        _guards.IsNotEqual(parentDto.Id, 0);
        _guards.IsNotEqual(parentDto.Id, childDto.Id);

        SourceFormatNode rootNode = await _sourceFormatNodeRepository.GetByIdWithRootNodeAsync(
                parentDto.Id,
                cancellationToken)
            .ConfigureAwait(false);
        SourceFormatNode resultNode = await _sourceFormatNodeRepository.AddChildNodeAsync(
                childDto.Id,
                parentDto.Id,
                rootNode.Id,
                cancellationToken)
            .ConfigureAwait(false);
        return _sourceFormatMappers.SourceFormatNodeMappers
            .MapSourceFormatNodeToSourceFormatNodeDtoInFlatFashion(resultNode);
    }
}