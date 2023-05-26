namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.SourceFormatNodeService;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions;
using Utils.GuardsService.Exceptions;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatServiceDatabaseOperationCollection")]
public class GetByIdValidationShould : BaseTest
{

    [Fact]
    public async Task Throw_GuardsServiceValueShouldNotBeEqualToException_WhenIdIsZero()
    {
        // Act
        Func<Task> task = async () =>
        {
            await Sut.SourceFormatNode.GetByIdAsync(0)
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<GuardsServiceValueShouldNotBeEqualToException>();
    }
}