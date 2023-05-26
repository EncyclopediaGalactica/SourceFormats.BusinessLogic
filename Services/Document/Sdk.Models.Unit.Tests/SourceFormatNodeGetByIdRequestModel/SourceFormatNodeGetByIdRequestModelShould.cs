namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeGetByIdRequestModel;

using System.Collections.Generic;
using System.Net.Http.Headers;
using Dtos;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

public class SourceFormatNodeGetByIdRequestModelShould
{
    [Fact]
    public void Build_RequestModel()
    {
        // Arrange & Act
        SourceFormatNodeGetByIdRequestModel requestModel = new SourceFormatNodeGetByIdRequestModel.Builder()
            .SetId(100)
            .Build();

        // Assert
        requestModel.Should().NotBeNull();
        requestModel.Should().BeOfType<SourceFormatNodeGetByIdRequestModel>();
        requestModel.Payload.Should().NotBeNull();
        requestModel.Payload.Should().BeOfType<SourceFormatNodeDto>();
        requestModel.Payload?.Id.Should().Be(100);
        requestModel.AcceptHeaders.Should().NotBeNull();
        requestModel.AcceptHeaders.Should().BeOfType<List<MediaTypeWithQualityHeaderValue>>();
    }
}