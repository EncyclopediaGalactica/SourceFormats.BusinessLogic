namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.SourceFormatNodeService;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using Interfaces;
using Interfaces.SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatServiceDatabaseOperationCollection")]
public class AddChildToParentShould : BaseTest
{
    [Fact]
    public async Task AddChildToParent_WhenParentIsAlreadyInTheTree_AndReturnResponseModelWithChildEntity()
    {
        // Arrange
        SourceFormatNodeDto rootNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("rootnode"))
            .ConfigureAwait(false);
        SourceFormatNodeDto parentNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("parent"))
            .ConfigureAwait(false);
        SourceFormatNodeDto childNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("child"))
            .ConfigureAwait(false);

        SourceFormatNodeDto addParentToRoot = await Sut.SourceFormatNode
            .AddChildToParentAsync(parentNode, rootNode)
            .ConfigureAwait(false);

        // Act
        SourceFormatNodeDto addChildToParent = await Sut.SourceFormatNode
            .AddChildToParentAsync(childNode, parentNode)
            .ConfigureAwait(false);

        // Assert
        addChildToParent.Should().BeOfType<SourceFormatNodeDto>();
        addChildToParent.Should().NotBeNull();
        addChildToParent.Id.Should().BeGreaterThan(0);
        addChildToParent.Name.Should().Be("child");

        SourceFormatNodeDto childNodeDetails = await Sut.SourceFormatNode
            .GetByIdAsync(childNode.Id)
            .ConfigureAwait(false);
        childNodeDetails.ParentNodeId.Should().Be(parentNode.Id);
        childNodeDetails.RootNodeId.Should().Be(rootNode.Id);
        childNodeDetails.IsRootNode.Should().Be(0);
    }

    [Fact]
    public async Task AddChildToParent_WhenParentIdRootNode_AndReturnResponseModelWithChildEntity()
    {
        // Arrange
        SourceFormatNodeDto rootNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("rootnode"))
            .ConfigureAwait(false);
        SourceFormatNodeDto parentNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("parent"))
            .ConfigureAwait(false);
        SourceFormatNodeDto childNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("child"))
            .ConfigureAwait(false);
        SourceFormatNodeDto childNode2 = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("child2"))
            .ConfigureAwait(false);
        SourceFormatNodeDto addParentToRoot = await Sut.SourceFormatNode
            .AddChildToParentAsync(parentNode, rootNode)
            .ConfigureAwait(false);
        SourceFormatNodeDto addChildToParent = await Sut.SourceFormatNode
            .AddChildToParentAsync(childNode, parentNode)
            .ConfigureAwait(false);

        // Act
        SourceFormatNodeDto addChild2ToRoot = await Sut.SourceFormatNode
            .AddChildToParentAsync(childNode2, rootNode)
            .ConfigureAwait(false);

        // Assert
        addChild2ToRoot.Should().BeOfType<SourceFormatNodeDto>();
        addChild2ToRoot.Should().NotBeNull();

        SourceFormatNodeDto child2 = await Sut.SourceFormatNode
            .GetByIdAsync(childNode2.Id)
            .ConfigureAwait(false);
        child2.Should().NotBeNull();
        child2.ParentNodeId.Should().Be(rootNode.Id);
    }

    [Fact]
    public async Task AddChildToParent_WhenParentIsNotRootButShouldBe_AndReturnResponseModelWithChildEntity()
    {
        // Arrange
        SourceFormatNodeDto parentNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("parent"))
            .ConfigureAwait(false);
        SourceFormatNodeDto childNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("child"))
            .ConfigureAwait(false);

        // Act
        SourceFormatNodeDto childNodeAdded = await Sut.SourceFormatNode
            .AddChildToParentAsync(childNode, parentNode)
            .ConfigureAwait(false);

        // Assert
        childNodeAdded.Should().NotBeNull();
        childNodeAdded.Should().BeOfType<SourceFormatNodeDto>();
        childNodeAdded.Id.Should().Be(childNode.Id);
        childNodeAdded.Name!.Should().Be(childNode.Name);

        SourceFormatNodeDto childNodeDetails = await Sut.SourceFormatNode
            .GetByIdAsync(childNode.Id)
            .ConfigureAwait(false);
        childNodeDetails.ParentNodeId.Should().Be(parentNode.Id);

        SourceFormatNodeDto parentNodeDetails = await Sut.SourceFormatNode
            .GetByIdAsync(parentNode.Id)
            .ConfigureAwait(false);
        parentNodeDetails.IsRootNode.Should().Be(1);
    }

    [Fact]
    public async Task Throw_InvalidOperationException_WhenNoSuchChildEntity()
    {
        // Arrange
        SourceFormatNodeDto parentNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("parent"))
            .ConfigureAwait(false);

        // Act
        Func<Task> task = async () =>
        {
            await Sut.SourceFormatNode
                .AddChildToParentAsync(new SourceFormatNodeDto { Id = 100 }, parentNode)
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task Throw_InvalidOperationException_When_NoSuchParentEntity()
    {
        // Arrange
        SourceFormatNodeDto childNode = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("parent"))
            .ConfigureAwait(false);

        // Act
        Func<Task> task = async () =>
        {
            await Sut.SourceFormatNode
                .AddChildToParentAsync(childNode, new SourceFormatNodeDto { Id = 100 })
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<InvalidOperationException>();
    }
}