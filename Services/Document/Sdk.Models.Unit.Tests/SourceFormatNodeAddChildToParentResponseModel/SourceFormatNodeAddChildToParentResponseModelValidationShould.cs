namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeAddChildToParentResponseModel;

using System;
using System.Net;
using Dtos;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

public class SourceFormatNodeAddChildToParentResponseModelValidationShould
{
    [Fact]
    public void Throw_WhenHttpStatusCode_IsNotProvided()
    {
        // Act
        Action action = () =>
        {
            SourceFormatNodeAddChildToParentResponseModel m =
                new SourceFormatNodeAddChildToParentResponseModel.Builder()
                    .SetMessage("asd")
                    .SetResult(new SourceFormatNodeDto())
                    .SetOperationSuccessful()
                    .Build();
        };

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Throw_WhenMessage_IsNotProvided()
    {
        // Act
        Action action = () =>
        {
            SourceFormatNodeAddChildToParentResponseModel m =
                new SourceFormatNodeAddChildToParentResponseModel.Builder()
                    .SetHttpStatusCode(HttpStatusCode.Accepted)
                    .SetResult(new SourceFormatNodeDto())
                    .SetOperationSuccessful()
                    .Build();
        };

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }
}