namespace EncyclopediaGalactica.SourceFormats.Mappers.SourceFormatNode;

using Dtos;
using Entities;
using Interfaces;

/// <inheritdoc />
public class SourceFormatNodeMappers : ISourceFormatNodeMappers
{
    /// <inheritdoc />
    public SourceFormatNode MapSourceFormatNodeDtoToSourceFormatNode(SourceFormatNodeDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        SourceFormatNode result = new SourceFormatNode();
        result.Id = dto.Id;
        result.Name = dto.Name;
        result.IsRootNode = dto.IsRootNode;

        return result;
    }

    /// <inheritdoc />
    public SourceFormatNodeDto MapSourceFormatNodeToSourceFormatNodeDtoInFlatFashion(SourceFormatNode node)
    {
        ArgumentNullException.ThrowIfNull(node);

        SourceFormatNodeDto result = new SourceFormatNodeDto();
        result.Id = node.Id;
        result.Name = node.Name;
        result.IsRootNode = node.IsRootNode;

        return result;
    }

    /// <inheritdoc />
    public List<SourceFormatNodeDto> MapSourceFormatNodesToSourceFormatNodeDtosInFlatFashion(
        List<SourceFormatNode> sourceFormatNodes)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatNodes);

        List<SourceFormatNodeDto> result = new List<SourceFormatNodeDto>();
        foreach (SourceFormatNode sourceFormatNode in sourceFormatNodes)
        {
            SourceFormatNodeDto elem = MapSourceFormatNodeToSourceFormatNodeDtoInFlatFashion(sourceFormatNode);
            result.Add(elem);
        }

        return result;
    }

    /// <inheritdoc />
    public SourceFormatNodeDto MapSourceFormatNodeToSourceFormatNodeDto(SourceFormatNode sourceFormatNode)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatNode);

        SourceFormatNodeDto dto = new SourceFormatNodeDto();
        dto.Id = sourceFormatNode.Id;
        dto.Name = sourceFormatNode.Name;
        dto.IsRootNode = sourceFormatNode.IsRootNode;
        dto.RootNodeId = sourceFormatNode.RootNodeId;
        dto.ParentNodeId = sourceFormatNode.ParentNodeId;

        return dto;
    }
}