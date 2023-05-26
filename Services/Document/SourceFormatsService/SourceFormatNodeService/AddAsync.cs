namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ValidatorService;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeDto> AddAsync(
        SourceFormatNodeDto dto,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(dto);
        await ValidateInputDataForAddingAsync(dto).ConfigureAwait(false);
        SourceFormatNode sourceFormatNode = MapSourceFormatNodeDtoToSourceFormatNode(dto);
        SourceFormatNode result = await PersistSourceFormatNodeAsync(sourceFormatNode, cancellationToken)
            .ConfigureAwait(false);
        //await AppendToSourceFormatNodesCachedList(result, SourceFormatNodesListKey);
        SourceFormatNodeDto mappedResult = MapSourceFormatNodeToSourceFormatNodeDto(result);

        _logger.LogInformation("{Method} is executed successfully", nameof(AddAsync));

        return mappedResult;
    }

    private SourceFormatNodeDto MapSourceFormatNodeToSourceFormatNodeDto(SourceFormatNode node)
    {
        return _sourceFormatMappers
            .SourceFormatNodeMappers
            .MapSourceFormatNodeToSourceFormatNodeDtoInFlatFashion(node);
    }

    private async Task AppendToSourceFormatNodesCachedList(SourceFormatNode node, string key)
    {
        await _sourceFormatNodeCacheService.AppendToCache(node, key, _cacheExpiresInMinutes);
    }

    private async Task<SourceFormatNode> PersistSourceFormatNodeAsync(
        SourceFormatNode newSourceFormatNode,
        CancellationToken cancellationToken)
    {
        SourceFormatNode result = await _sourceFormatNodeRepository.AddAsync(
                newSourceFormatNode,
                cancellationToken)
            .ConfigureAwait(false);
        return result;
    }

    private SourceFormatNode MapSourceFormatNodeDtoToSourceFormatNode(SourceFormatNodeDto dto)
    {
        return _sourceFormatMappers.SourceFormatNodeMappers.MapSourceFormatNodeDtoToSourceFormatNode(dto);
    }

    private async Task ValidateInputDataForAddingAsync(SourceFormatNodeDto dto)
    {
        await _sourceFormatNodeDtoValidator.ValidateAsync(dto, o =>
        {
            o.IncludeRuleSets(SourceFormatNodeDtoValidator.Add);
            o.ThrowOnFailures();
        }).ConfigureAwait(false);
    }
}