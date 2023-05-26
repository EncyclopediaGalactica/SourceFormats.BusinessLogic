namespace EncyclopediaGalactica.SourceFormats.Dtos.Unit.Tests;

using FluentAssertions;
using Xunit;

public class SourceFormatNodeDtoShould
{
    [Fact]
    public void DoNotChangeValues()
    {
        // Arrange
        long id = 100;
        string name = "name";
        int isRootNode = 1;
        long parentNodeId = 200;
        long rootNodeId = 300;

        // Act
        SourceFormatNodeDto dto = new SourceFormatNodeDto
        {
            Id = id,
            Name = name,
            IsRootNode = isRootNode,
            ParentNodeId = parentNodeId,
            RootNodeId = rootNodeId
        };

        // Assert
        dto.Id.Should().Be(id);
        dto.Name.Should().Be(name);
        dto.IsRootNode.Should().Be(isRootNode);
        dto.ParentNodeId.Should().Be(parentNodeId);
        dto.RootNodeId.Should().Be(rootNodeId);
    }
}