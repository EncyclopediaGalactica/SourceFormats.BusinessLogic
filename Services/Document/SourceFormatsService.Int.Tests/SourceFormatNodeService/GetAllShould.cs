namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.SourceFormatNodeService;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using Interfaces;
using Interfaces.SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatServiceDatabaseOperationCollection")]
public class GetAllShould : BaseTest
{
    [Fact]
    public async Task ReturnResponseModel_AllEntities_WhenThereAreEntitiesInTheDb()
    {
        // Arrange
        string name = "asdasd";
        SourceFormatNodeDto dto = new()
        {
            Name = name
        };

        await Sut.SourceFormatNode
            .AddAsync(dto)
            .ConfigureAwait(false);

        // Act
        List<SourceFormatNodeDto> result = await Sut.SourceFormatNode
            .GetAllAsync()
            .ConfigureAwait(false);

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().BeGreaterThan(0);
        SourceFormatNodeDto elem = result.ElementAt(0);
        elem.Name.Should().Be(name);
    }

    [Fact]
    public async Task ReturnsResponseModel_EmptyList_WhenThereAreNoEntitiesInTheDb()
    {
        // Act
        List<SourceFormatNodeDto> result = await Sut.SourceFormatNode.GetAllAsync()
            .ConfigureAwait(false);

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(0);
    }
}