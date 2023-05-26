namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeGetAllRequestModel;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
public class SourceFormatNodeGetAllRequestShould
{
    [Fact]
    public void Build_SourceFormatNodeGetAllRequestModel()
    {
        // Act
        SourceFormatNodeGetAllRequestModel requestModel = new SourceFormatNodeGetAllRequestModel.Builder()
            .Build();

        // Assert
        requestModel.Should().NotBeNull();
        requestModel.Should().BeOfType<SourceFormatNodeGetAllRequestModel>();
        requestModel.Payload.Should().BeNull();
        requestModel.AcceptHeaders.Should().NotBeNull();
        requestModel.AcceptHeaders.Should().BeOfType<List<MediaTypeWithQualityHeaderValue>>();
    }
}