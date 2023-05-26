namespace EncyclopediaGalactica.SourceFormats.Entities.Unit.Tests;

using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SourceFormatNodeProperties_Should
{
    [Fact]
    public void IdWontChange()
    {
        long id = 100L;
        SourceFormatNode node = new SourceFormatNode();
        node.Id = id;

        node.Id.Should().Be(id);
    }

    [Fact]
    public void IdDefaultValueIsZero()
    {
        SourceFormatNode node = new SourceFormatNode();
        node.Id.Should().Be(0L);
    }

    [Fact]
    public void NameWontChange()
    {
        string name = "asdasd";
        SourceFormatNode node = new SourceFormatNode();
        node.Name = name;

        node.Name.Should().Be(name);
    }

    [Fact]
    public void NameDefaultValueIsNull()
    {
        SourceFormatNode node = new SourceFormatNode();
        node.Name.Should().BeNull();
    }

    [Fact]
    public void IsRootNodeDefaultValueIsZero()
    {
        SourceFormatNode node = new SourceFormatNode();
        node.IsRootNode.Should().Be(0);
    }

    [Fact]
    public void IsRootNodeValueDoesntChange()
    {
        int isRoot = 1;
        SourceFormatNode node = new SourceFormatNode();
        node.IsRootNode = isRoot;

        node.IsRootNode.Should().Be(isRoot);
    }

    [Fact]
    public void ParentNodeIdDefaultValueIsNull()
    {
        SourceFormatNode node = new SourceFormatNode();
        node.ParentNodeId.Should().BeNull();
    }

    [Fact]
    public void ParentNodeIdValueDoesntChange()
    {
        long parentId = 100L;
        SourceFormatNode node = new SourceFormatNode();
        node.ParentNodeId = parentId;

        node.ParentNodeId.Should().Be(parentId);
    }

    [Fact]
    public void RootNodeIdDefaultIsNull()
    {
        SourceFormatNode node = new SourceFormatNode();
        node.RootNodeId.Should().BeNull();
    }

    [Fact]
    public void RootNodeIdValueDoesntChange()
    {
        long rootNodeId = 100L;
        SourceFormatNode node = new SourceFormatNode();
        node.RootNodeId = rootNodeId;

        node.RootNodeId.Should().Be(rootNodeId);
    }

    [Fact]
    public void ChildrenSourceFormatNodesListIsEmptyByDefault()
    {
        SourceFormatNode node = new SourceFormatNode();
        node.ChildrenSourceFormatNodes.Should().BeEmpty();
    }
}