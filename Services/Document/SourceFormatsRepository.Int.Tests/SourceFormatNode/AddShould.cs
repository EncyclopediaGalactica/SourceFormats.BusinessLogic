namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Int.Tests.SourceFormatNode;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Entities;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatNode Repository Collection")]
public class AddShould : BaseTest
{
    [Fact]
    public async Task Add_ANewNode()
    {
        // Arrange
        SourceFormatNode node = new SourceFormatNode();
        node.Name = "name";

        // Act
        SourceFormatNode res = await Sut.SourceFormatNodes.AddAsync(node).ConfigureAwait(false);

        // Assert
        res.Name.Should().Be(node.Name);
    }

    [Fact]
    public async Task Throw_WhenInputIsNull()
    {
        // Arrange & Act
        Func<Task> task = async () => { await Sut.SourceFormatNodes.AddAsync(null!).ConfigureAwait(false); };

        // Assert
        await task.Should()
            .ThrowExactlyAsync<ArgumentNullException>()
            .ConfigureAwait(false);
    }
}