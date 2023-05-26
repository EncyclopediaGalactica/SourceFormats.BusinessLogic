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
public class GetAll : BaseTest
{
    private Random _random = new Random();

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(10)]
    public async Task ReturnAll(int counter)
    {
        // Arrange
        for (int i = 0; i < counter; i++)
        {
            SourceFormatNode node = new SourceFormatNode();
#pragma warning disable CA5394
            node.Name = "tmp" + _random.Next(1, 1000000000);
#pragma warning restore CA5394
            await Sut.SourceFormatNodes.AddAsync(node).ConfigureAwait(false);
        }

        // Act
        ICollection<SourceFormatNode> result = await Sut.SourceFormatNodes.GetAllAsync().ConfigureAwait(false);

        // Assert
        result.Count.Should().Be(counter);
    }
}