namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.SourceFormatNodeService;

using Dtos;
using Entities;
using FluentValidation;
using Interfaces;
using Interfaces.SourceFormatNode;
using ValidatorService;

public partial class SourceFormatNodeService
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeDto> UpdateSourceFormatNodeAsync(
        SourceFormatNodeDto? dto,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(dto);
        _guards.IsNotEqual(dto.Id, 0);
        await ValidateInputDataForUpdateAsync(dto).ConfigureAwait(false);
        SourceFormatNode updateTemplate = MapSourceFormatNodeDtoToSourceFormatNode(dto);
        SourceFormatNode updated = await _sourceFormatNodeRepository.UpdateAsync(updateTemplate, cancellationToken)
            .ConfigureAwait(false);
        // TODO: caching!
        return MapSourceFormatNodeToSourceFormatNodeDto(updated);
    }

    private async Task ValidateInputDataForUpdateAsync(SourceFormatNodeDto inputDto)
    {
        await _sourceFormatNodeDtoValidator.ValidateAsync(inputDto, options =>
        {
            options.IncludeRuleSets(SourceFormatNodeDtoValidator.Update);
            options.ThrowOnFailures();
        }).ConfigureAwait(false);
    }
}