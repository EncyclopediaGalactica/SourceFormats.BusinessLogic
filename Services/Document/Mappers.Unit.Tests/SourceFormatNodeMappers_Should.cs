namespace EncyclopediaGalactica.SourceFormats.Mappers.Unit.Tests;

using System.Diagnostics.CodeAnalysis;
using Document;
using Dtos;
using Entities;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("Mappers")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SourceFormatNodeMappers_Should
{
    private readonly SourceFormatMappers _mappers;

    public SourceFormatNodeMappers_Should()
    {
        _mappers = new SourceFormatMappers(
            new SourceFormatNodeMappers(), new DocumentMappers());
    }

    [Fact]
    public void SingleEntityToDto_InFlatFashion()
    {
        // Arrange
        SourceFormatNode node = new SourceFormatNode
        {
            Id = 100,
            Name = "name",
            IsRootNode = 1,
        };

        // Act
        SourceFormatNodeDto dto = _mappers.SourceFormatNodeMappers
            .MapSourceFormatNodeToSourceFormatNodeDtoInFlatFashion(node);

        // Assert
        dto.Id.Should().Be(node.Id);
        dto.Name.Should().Be(node.Name);
        dto.IsRootNode.Should().Be(node.IsRootNode);
    }

    [Fact]
    public void SingleDtoToEntity()
    {
        // Arrange
        SourceFormatNodeDto dto = new SourceFormatNodeDto
        {
            Id = 100,
            Name = "name",
            IsRootNode = 1
        };

        // Act
        SourceFormatNode node = _mappers.SourceFormatNodeMappers.MapSourceFormatNodeDtoToSourceFormatNode(dto);

        // Assert
        node.Id.Should().Be(dto.Id);
        node.Name.Should().Be(dto.Name);
        node.IsRootNode.Should().Be(dto.IsRootNode);
    }
}