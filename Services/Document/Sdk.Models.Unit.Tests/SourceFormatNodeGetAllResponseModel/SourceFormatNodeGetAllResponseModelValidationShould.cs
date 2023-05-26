namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeGetAllResponseModel;

using System;
using System.Collections.Generic;
using System.Net;
using Dtos;
using FluentAssertions;
using SourceFormatNode;
using Xunit;

public class SourceFormatNodeGetAllResponseModelValidationShould
{
    [Fact]
    public void Throw_WhenHttpStatusCode_IsNotProvided()
    {
        // Act
        Action action = () =>
        {
            SourceFormatNodeGetAllResponseModel m = new SourceFormatNodeGetAllResponseModel.Builder()
                .SetMessage("asd")
                .SetResult(new List<SourceFormatNodeDto>())
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
            SourceFormatNodeGetAllResponseModel m = new SourceFormatNodeGetAllResponseModel.Builder()
                .SetHttpStatusCode(HttpStatusCode.Accepted)
                .SetResult(new List<SourceFormatNodeDto>())
                .SetOperationSuccessful()
                .Build();
        };

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }
}