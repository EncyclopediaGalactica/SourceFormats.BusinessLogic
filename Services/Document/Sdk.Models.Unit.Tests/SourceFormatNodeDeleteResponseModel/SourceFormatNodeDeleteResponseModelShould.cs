namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeDeleteResponseModel;

using System.Diagnostics.CodeAnalysis;
using System.Net;
using Dtos;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

[ExcludeFromCodeCoverage]
public class SourceFormatNodeDeleteResponseModelShould
{
    [Fact]
    public void Throw_WhenHttpStatusCode_IsNotProvided()
    {
        // Arrange
        string message = "asd";
        HttpStatusCode code = HttpStatusCode.Accepted;

        // Act
        SourceFormatNodeDeleteResponseModel model = new SourceFormatNodeDeleteResponseModel.Builder()
            .SetMessage(message)
            .SetResult(new SourceFormatNodeDto())
            .SetOperationSuccessful()
            .SetHttpStatusCode(code)
            .Build();

        // Assert
        model.Message.Should().NotBeNull();
        model.Message.Should().BeOfType<string>();
        model.Message.Should().Be(message);
        model.Result.Should().NotBeNull();
        model.Result.Should().BeOfType<SourceFormatNodeDto>();
        model.IsOperationSuccessful.Should().Be(true);
    }
}