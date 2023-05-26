namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.SourceFormatNodeService;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using Interfaces;
using Interfaces.SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatServiceDatabaseOperationCollection")]
public class DeleteShould : BaseTest
{
    [Fact]
    public async Task DeleteItem()
    {
        // Arrange
        SourceFormatNodeDto nodeResult = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("asd")).ConfigureAwait(false);

        // Act
        SourceFormatNodeDto dto = new SourceFormatNodeDto { Id = nodeResult.Id };
        await Sut.SourceFormatNode.DeleteAsync(dto).ConfigureAwait(false);

        // Assert
        List<SourceFormatNodeDto> list =
            await Sut.SourceFormatNode.GetAllAsync().ConfigureAwait(false);
        list.Count.Should().Be(0);
    }

    [Fact]
    public async Task DeleteItemWithItsChildren()
    {
        // Arrange
        SourceFormatNodeDto otherOne = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("other"))
            .ConfigureAwait(false);

        SourceFormatNodeDto rootNodeDto = new SourceFormatNodeDto();
        rootNodeDto.Name = "root";
        rootNodeDto.IsRootNode = 1;
        SourceFormatNodeDto rootNodeResult =
            await Sut.SourceFormatNode.AddAsync(rootNodeDto).ConfigureAwait(false);

        // SourceFormatNode rootOfTheTree = new SourceFormatNode();
        // rootOfTheTree.Id = rootNodeDto.Id;
        // rootOfTheTree.Name = rootNodeDto.Name;
        // rootOfTheTree.RootNodeId = rootNodeResult.Id;
        // SourceFormatNode setupRootNodeResult =
        // await _sourceFormatsService.SourceFormatNodes.UpdateAsync(rootOfTheTree).ConfigureAwait(false);

        // first level
        SourceFormatNodeDto firstFirst = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("first_first"))
            .ConfigureAwait(false);
        SourceFormatNodeDto firstFirstResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(firstFirst, rootNodeResult)
            .ConfigureAwait(false);

        SourceFormatNodeDto firstSecond = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("first_second"))
            .ConfigureAwait(false);
        SourceFormatNodeDto firstSecondResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(firstSecond, rootNodeResult)
            .ConfigureAwait(false);

        SourceFormatNodeDto firstThird = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("first_third"))
            .ConfigureAwait(false);
        SourceFormatNodeDto firstThirdResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(firstThird, rootNodeResult)
            .ConfigureAwait(false);

        // second level - one - parent: first_first
        SourceFormatNodeDto secondOneOne =
            await Sut.SourceFormatNode.AddAsync(new SourceFormatNodeDto("secondOne_one"))
                .ConfigureAwait(false);
        SourceFormatNodeDto secondOneOneResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondOneOne, firstFirst)
            .ConfigureAwait(false);
        SourceFormatNodeDto secondOneTwo = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("secondOne_two"))
            .ConfigureAwait(false);
        SourceFormatNodeDto secondOneTwoResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondOneTwo, firstFirst)
            .ConfigureAwait(false);
        SourceFormatNodeDto secondOneThree = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("secondOne_three"))
            .ConfigureAwait(false);
        SourceFormatNodeDto secondOneThreeResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondOneThree, firstFirst)
            .ConfigureAwait(false);

        // second level - two - parent: first_second
        SourceFormatNodeDto secondTwoOne = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("secondTwo_one"))
            .ConfigureAwait(false);
        SourceFormatNodeDto secondTwoOneResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondTwoOne, firstSecond)
            .ConfigureAwait(false);
        SourceFormatNodeDto secondTwoTwo = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("secondTwo_two"))
            .ConfigureAwait(false);
        SourceFormatNodeDto secondTwoTwoResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondTwoTwo, firstSecond)
            .ConfigureAwait(false);
        SourceFormatNodeDto secondTwoThree = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("secondTwo_three"))
            .ConfigureAwait(false);
        SourceFormatNodeDto secondTwoThreeResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondTwoThree, firstSecond)
            .ConfigureAwait(false);

        // second level - three - parent: first_third
        SourceFormatNodeDto secondThreeOne = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("secondThree_one"))
            .ConfigureAwait(false);
        SourceFormatNodeDto secondThreeOneResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondThreeOne, firstThird)
            .ConfigureAwait(false);
        SourceFormatNodeDto secondThreeTwo = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("secondThree_two"))
            .ConfigureAwait(false);
        SourceFormatNodeDto secondThreeTwoResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondThreeTwo, firstThird)
            .ConfigureAwait(false);
        SourceFormatNodeDto secondThreeThree = await Sut.SourceFormatNode
            .AddAsync(new SourceFormatNodeDto("secondThree_three"))
            .ConfigureAwait(false);
        SourceFormatNodeDto secondThreeThreeResult = await Sut.SourceFormatNode
            .AddChildToParentAsync(secondThreeThree, firstThird)
            .ConfigureAwait(false);

        // Act
        await Sut.SourceFormatNode.DeleteAsync(rootNodeResult)
            .ConfigureAwait(false);

        // Assert
        List<SourceFormatNodeDto> list = await Sut.SourceFormatNode.GetAllAsync()
            .ConfigureAwait(false);
        list.Count.Should().Be(1);
    }

    [Fact]
    public async Task Throw_InvalidOperationException_WhenNoSuchEntity()
    {
        // Act
        Func<Task> task = async () =>
        {
            await Sut.SourceFormatNode.DeleteAsync(new SourceFormatNodeDto { Id = 100 })
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<InvalidOperationException>();
    }
}