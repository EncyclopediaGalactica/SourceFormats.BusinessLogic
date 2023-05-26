namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.SourceFormatNodeService;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using FluentValidation;
using Interfaces;
using Interfaces.SourceFormatNode;
using QA.Datasets;
using Utils.GuardsService.Exceptions;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatServiceDatabaseOperationCollection")]
public class UpdateValidationShould : BaseTest
{
    [Fact]
    public async Task Throw_ArgumentNullException_WhenInputIsNull()
    {
        // Act
        Func<Task> task = async() =>
        {
            await Sut.SourceFormatNode
                .UpdateSourceFormatNodeAsync(null)
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task Throw_GuardsServiceValueShouldNotBeEqualToException_WhenInputIdIsZero()
    {
        // Act
        Func<Task> task = async() =>
        {
            await Sut.SourceFormatNode
                .UpdateSourceFormatNodeAsync(new SourceFormatNodeDto{Id = 0})
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<GuardsServiceValueShouldNotBeEqualToException>();
    }

    [Theory]
    [MemberData(nameof(SourceFormatNodeDatasets.UpdateValidationDataSet_Without_IdIsZero),
        MemberType = typeof(SourceFormatNodeDatasets))]
    public async Task Throw_ValidationError_WhenInputIsInvalid(int id, string name)
    {
        // Act
        SourceFormatNodeDto dto = new()
        {
            Id = id,
            Name = name
        };
        Func<Task> task = async() =>
        {
            await Sut.SourceFormatNode
                .UpdateSourceFormatNodeAsync(dto)
                .ConfigureAwait(false);
        };

        // Assert
        await task.Should().ThrowExactlyAsync<ValidationException>();
    }
}