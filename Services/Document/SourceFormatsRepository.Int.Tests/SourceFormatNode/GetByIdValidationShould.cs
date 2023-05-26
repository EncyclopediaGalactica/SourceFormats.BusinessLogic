namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Int.Tests.SourceFormatNode;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions;
using Utils.GuardsService.Exceptions;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatNode Repository Collection")]
public class GetByIdValidationShould : BaseTest
{
    [Fact]
    public async Task Throw_WhenIdIsZero()
    {
        // Act
        Func<Task> action = async () => { await Sut.SourceFormatNodes.GetByIdAsync(0).ConfigureAwait(false); };

        // Assert
        await action.Should()
            .ThrowExactlyAsync<GuardsServiceValueShouldNotBeEqualToException>()
            .ConfigureAwait(false);
    }

    [Fact]
    public async Task Throw_WhenNoSuchEntity()
    {
        // Act
        Func<Task> action = async () => { await Sut.SourceFormatNodes.GetByIdAsync(100).ConfigureAwait(false); };

        // Assert
        await action.Should()
            .ThrowExactlyAsync<InvalidOperationException>()
            .ConfigureAwait(false);
    }
}