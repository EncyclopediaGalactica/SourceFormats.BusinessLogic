namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.SourceFormatNodeService;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using FluentValidation;
using QA.Datasets;
using Utils.GuardsService.Exceptions;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatServiceDatabaseOperationCollection")]
public class AddChildToParentValidation : BaseTest
{
    [Theory]
    [MemberData(nameof(SourceFormatNodeDatasets.Service_AddChildToParentAsync_NullInput_Dataset),
        MemberType = typeof(SourceFormatNodeDatasets))]
    public async Task Throw_ArgumentNullException_WhenInputsAreNull(
        SourceFormatNodeDto child,
        SourceFormatNodeDto parent)
    {
        // Act
        Func<Task> task = async () =>
        {
            await Sut.SourceFormatNode
                .AddChildToParentAsync(child, parent)
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Theory]
    [MemberData(nameof(SourceFormatNodeDatasets.Service_AddChildToParentAsync_NullInput_Dataset),
        MemberType = typeof(SourceFormatNodeDatasets))]
    public async Task Throw_ArgumentNullException_WhenInputsAreInvalid(
        SourceFormatNodeDto child,
        SourceFormatNodeDto parent)
    {
        // Act
        Func<Task> task = async () =>
        {
            await Sut.SourceFormatNode
                .AddChildToParentAsync(child, parent)
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Theory]
    [MemberData(nameof(SourceFormatNodeDatasets.Service_AddChildToParentAsync_InvalidInput_Dataset),
        MemberType = typeof(SourceFormatNodeDatasets))]
    public async Task Throw_GuardsServiceValueShouldNotBeEqualToException_WhenInputNodeIdsAreInvalid(
        SourceFormatNodeDto child,
        SourceFormatNodeDto parent)
    {
        // Act
        Func<Task> task = async () =>
        {
            await Sut.SourceFormatNode
                .AddChildToParentAsync(child, parent)
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<GuardsServiceValueShouldNotBeEqualToException>();
    }
}