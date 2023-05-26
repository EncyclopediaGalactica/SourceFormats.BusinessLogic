namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.SourceFormatNodeService;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using Interfaces;
using Interfaces.SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
[Collection("SourceFormatServiceDatabaseOperationCollection")]
public class AddShould : BaseTest
{
    [Fact]
    public async Task ReturnsResponseModel_SuccessCode_AndWithOperationResult()
    {
        // Arrange
        string name = "asd";
        SourceFormatNodeDto dto = new()
        {
            Name = name
        };

        // Act
        SourceFormatNodeDto result = await Sut
            .SourceFormatNode
            .AddAsync(dto).ConfigureAwait(false);

        // Assert
        result.Should().NotBeNull();
        result.Should().NotBeNull();
        result.Id.Should().NotBe(0);
        result.Id.Should().BeGreaterThan(0);
        result.Name.Should().Be(name);
    }
}