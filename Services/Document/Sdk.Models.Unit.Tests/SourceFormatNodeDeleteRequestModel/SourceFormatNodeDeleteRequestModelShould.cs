namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeDeleteRequestModel;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using Dtos;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
public class SourceFormatNodeDeleteRequestModelShould
{
    [Fact]
    public void Build_SourceFormatNodeDeleteRequestModel()
    {
        // Arrange
        long id = 100;
        string header = "application/json";

        // Act
        SourceFormatNodeDeleteRequestModel model = new SourceFormatNodeDeleteRequestModel.Builder()
            .SetId(id)
            .AddAcceptHeader(header)
            .Build();

        // Assert
        model.Should().BeOfType<SourceFormatNodeDeleteRequestModel>();
        model.Payload.Should().NotBeNull();
        model.Payload.Should().BeOfType<SourceFormatNodeDto>();
        model.Payload!.Id.Should().Be(id);
        model.AcceptHeaders.Should().NotBeNull();
        model.AcceptHeaders.Should().BeOfType<List<MediaTypeWithQualityHeaderValue>>();
        model.AcceptHeaders.Where(p => p.MediaType == header).ToList().Count.Should().Be(1);
    }
}