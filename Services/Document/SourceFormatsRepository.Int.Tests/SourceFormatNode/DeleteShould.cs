namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Int.Tests.SourceFormatNode;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Entities;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatNode Repository Collection")]
public class DeleteShould : BaseTest
{
    [Fact]
    public async Task DeleteItem()
    {
        // Arrange
        SourceFormatNode node = await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("asd")).ConfigureAwait(false);

        // Act
        await Sut.SourceFormatNodes.DeleteAsync(node.Id).ConfigureAwait(false);

        // Assert
        List<SourceFormatNode> list = await Sut.SourceFormatNodes.GetAllAsync().ConfigureAwait(false);
        list.Count.Should().Be(0);
    }

    [Fact]
    public async Task DeleteItemWithItsChildren()
    {
        // Arrange
        SourceFormatNode otherOne =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("other")).ConfigureAwait(false);

        SourceFormatNode rootNode = new SourceFormatNode();
        rootNode.Name = "root";
        rootNode.IsRootNode = 1;
        SourceFormatNode rootNodeResult = await Sut.SourceFormatNodes.AddAsync(rootNode).ConfigureAwait(false);

        SourceFormatNode setupRootNode = new SourceFormatNode();
        setupRootNode.Id = rootNode.Id;
        setupRootNode.Name = rootNode.Name;
        setupRootNode.RootNodeId = rootNodeResult.Id;
        SourceFormatNode setupRootNodeResult =
            await Sut.SourceFormatNodes.UpdateAsync(setupRootNode).ConfigureAwait(false);

        // first level
        SourceFormatNode firstFirst = await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("first_first"))
            .ConfigureAwait(false);
        SourceFormatNode firstFirstResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            firstFirst.Id,
            rootNodeResult.Id,
            rootNodeResult.Id).ConfigureAwait(false);

        SourceFormatNode firstSecond = await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("first_second"))
            .ConfigureAwait(false);
        SourceFormatNode firstSecondResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            firstSecond.Id,
            rootNodeResult.Id,
            rootNodeResult.Id).ConfigureAwait(false);

        SourceFormatNode firstThird = await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("first_third"))
            .ConfigureAwait(false);
        SourceFormatNode firstThirdResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            firstThird.Id,
            rootNodeResult.Id,
            rootNodeResult.Id).ConfigureAwait(false);

        // second level - one - parent: first_first
        SourceFormatNode secondOneOne =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondOne_one")).ConfigureAwait(false);
        SourceFormatNode secondOneOneResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondOneOne.Id,
            firstFirst.Id,
            rootNodeResult.Id).ConfigureAwait(false);
        SourceFormatNode secondOneTwo =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondOne_two")).ConfigureAwait(false);
        SourceFormatNode secondOneTwoResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondOneTwo.Id,
            firstFirst.Id,
            rootNodeResult.Id).ConfigureAwait(false);
        SourceFormatNode secondOneThree =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondOne_three")).ConfigureAwait(false);
        SourceFormatNode secondOneThreeResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondOneThree.Id,
            firstFirst.Id,
            rootNodeResult.Id).ConfigureAwait(false);

        // second level - two - parent: first_second
        SourceFormatNode secondTwoOne =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondTwo_one")).ConfigureAwait(false);
        SourceFormatNode secondTwoOneResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondTwoOne.Id,
            firstSecond.Id,
            rootNodeResult.Id).ConfigureAwait(false);
        SourceFormatNode secondTwoTwo =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondTwo_two")).ConfigureAwait(false);
        SourceFormatNode secondTwoTwoResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondTwoTwo.Id,
            firstSecond.Id,
            rootNodeResult.Id).ConfigureAwait(false);
        SourceFormatNode secondTwoThree =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondTwo_three")).ConfigureAwait(false);
        SourceFormatNode secondTwoThreeResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondTwoThree.Id,
            firstSecond.Id,
            rootNodeResult.Id).ConfigureAwait(false);

        // second level - three - parent: first_third
        SourceFormatNode secondThreeOne =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondThree_one")).ConfigureAwait(false);
        SourceFormatNode secondThreeOneResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondThreeOne.Id,
            firstThird.Id,
            rootNodeResult.Id).ConfigureAwait(false);
        SourceFormatNode secondThreeTwo =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondThree_two")).ConfigureAwait(false);
        SourceFormatNode secondThreeTwoResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondThreeTwo.Id,
            firstThird.Id,
            rootNodeResult.Id).ConfigureAwait(false);
        SourceFormatNode secondThreeThree =
            await Sut.SourceFormatNodes.AddAsync(new SourceFormatNode("secondThree_three")).ConfigureAwait(false);
        SourceFormatNode secondThreeThreeResult = await Sut.SourceFormatNodes.AddChildNodeAsync(
            secondThreeThree.Id,
            firstThird.Id,
            rootNodeResult.Id).ConfigureAwait(false);

        // Act
        await Sut.SourceFormatNodes.DeleteAsync(rootNode.Id).ConfigureAwait(false);

        // Assert
        List<SourceFormatNode> list = await Sut.SourceFormatNodes.GetAllAsync().ConfigureAwait(false);
        list.Count.Should().Be(1);
    }

    [Fact]
    public async Task ThrowWhenNoSuchEntity()
    {
        // Act
        Func<Task> action = async () => { await Sut.SourceFormatNodes.DeleteAsync(100).ConfigureAwait(false); };

        // Assert
        await action.Should()
            .ThrowExactlyAsync<InvalidOperationException>()
            .ConfigureAwait(false);
    }
}