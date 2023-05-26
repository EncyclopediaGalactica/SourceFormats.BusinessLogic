namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeAddRequestModel;

using System.Diagnostics.CodeAnalysis;
using Dtos;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
public class SourceFormatNodeAddModelShould
{
    [Fact]
    public void BuildObject()
    {
        // Arrange & Act
        SourceFormatNodeAddRequestModel requestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("asd")
            .Build();

        // Assert
        requestModel.Should().BeOfType<SourceFormatNodeAddRequestModel>();
        requestModel.Payload.Should().BeOfType<SourceFormatNodeDto>();
    }
}