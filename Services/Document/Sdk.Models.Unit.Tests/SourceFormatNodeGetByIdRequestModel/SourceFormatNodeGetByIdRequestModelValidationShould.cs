namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeGetByIdRequestModel;

using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
public class SourceFormatNodeGetByIdRequestModelValidationShould
{
    [Fact]
    public void Throw_WhenARequestModelIsBuilt_WithoutId()
    {
        // Arrange
        Action action = () =>
        {
            SourceFormatNodeGetByIdRequestModel model = new SourceFormatNodeGetByIdRequestModel.Builder()
                .Build();
        };

        // Assert
        action.Should().ThrowExactly<SdkModelsException>();
    }

    [Fact]
    public void Throw_WhenARequestModelIsBuilt_WithIdZero()
    {
        // Arrange
        Action action = () =>
        {
            SourceFormatNodeGetByIdRequestModel model = new SourceFormatNodeGetByIdRequestModel.Builder()
                .SetId(0)
                .Build();
        };

        // Assert
        action.Should().ThrowExactly<SdkModelsException>();
    }
}