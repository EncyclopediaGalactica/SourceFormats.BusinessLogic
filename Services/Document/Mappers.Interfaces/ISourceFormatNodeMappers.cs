namespace EncyclopediaGalactica.SourceFormats.Mappers.Interfaces;

using Dtos;
using Entities;

public interface ISourceFormatNodeMappers
{
    /// <summary>
    ///     Maps <see cref="SourceFormatNodeDto" /> to a <see cref="SourceFormatNode" />
    /// </summary>
    /// <param name="dto">The dto to be mapped</param>
    /// <exception cref="ArgumentNullException">
    ///     Input parameter is null
    /// </exception>
    /// <returns>
    ///     Returns a <see cref="SourceFormatNode" /> object
    /// </returns>
    SourceFormatNode MapSourceFormatNodeDtoToSourceFormatNode(SourceFormatNodeDto dto);

    /// <summary>
    ///     Maps a <see cref="SourceFormatNode" /> to a <see cref="SourceFormatNodeDto" />.
    ///     It does in the way the <see cref="SourceFormatNode" /> relations are not carried through, meaning
    ///     navigation properties are not populated.
    /// </summary>
    /// <param name="node">The <see cref="SourceFormatNodeDto" /> elem going to be mapped</param>
    /// <exception cref="ArgumentNullException">
    ///     Input parameter is null
    /// </exception>
    /// <returns>
    ///     Returns a <see cref="SourceFormatNodeDto" /> which property values equal to the original one.
    /// </returns>
    SourceFormatNodeDto MapSourceFormatNodeToSourceFormatNodeDtoInFlatFashion(SourceFormatNode node);

    /// <summary>
    ///     Maps <see cref="SourceFormatNode" /> elements of a list to <see cref="SourceFormatNodeDto" />.
    ///     Does the mapping in the way the relations are not carried through,
    ///     meaning the navigation properties are not populated.
    /// </summary>
    /// <param name="sourceFormatNodes">The list of <see cref="SourceFormatNodeDto" /></param>
    /// <returns>
    ///     <see cref="List{T}" /> representing the result of operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     Input parameter is null
    /// </exception>
    List<SourceFormatNodeDto> MapSourceFormatNodesToSourceFormatNodeDtosInFlatFashion(
        List<SourceFormatNode> sourceFormatNodes);

    /// <summary>
    ///     Maps the provided <see cref="SourceFormatNode" /> object to a <see cref="SourceFormatNodeDto" />.
    ///     The mapping includes all properties, even those which has a list or tree structure.
    /// </summary>
    /// <param name="sourceFormatNode">The object should be mapped</param>
    /// <returns>
    ///     Returns a <see cref="SourceFormatNodeDto" /> object where its property values are equal to the original,
    ///     provided object properties
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     Input parameter is null
    /// </exception>
    SourceFormatNodeDto MapSourceFormatNodeToSourceFormatNodeDto(SourceFormatNode sourceFormatNode);
}