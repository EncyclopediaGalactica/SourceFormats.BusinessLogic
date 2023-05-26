namespace EncyclopediaGalactica.SourceFormats.E2E.SourceFormatNode;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using Sdk.Models;
using Sdk.Models.SourceFormatNode;
using SourceFormatsService.Interfaces;
using Xunit;

public partial class SourceFormatNodeSdk_Should
{
    [Fact]
    public void Throw_WhenTheUserTriesToBuildRequestModel_WithoutId()
    {
        // Act
        Action action = () =>
        {
            SourceFormatNodeDeleteRequestModel requestModel = new SourceFormatNodeDeleteRequestModel.Builder()
                .Build();
        };

        // Assert
        action.Should().ThrowExactly<SdkModelsException>();
    }

    [Fact]
    public async Task Return_201_WhenEntityIsDeleted_AndReturnOperationDetails()
    {
        // Arrange
        SourceFormatNodeAddRequestModel addRequestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("asd")
            .Build();
        SourceFormatNodeAddResponseModel addResponseModel = await SourceFormatsSdk.SourceFormatNode
            .AddAsync(addRequestModel)
            .ConfigureAwait(false);

        // Act
        SourceFormatNodeDeleteRequestModel deleteRequestModel = new SourceFormatNodeDeleteRequestModel.Builder()
            .SetId(addResponseModel.Result.Id)
            .Build();
        SourceFormatNodeDeleteResponseModel deleteResponseModel = await SourceFormatsSdk.SourceFormatNode
            .DeleteAsync(deleteRequestModel).ConfigureAwait(false);

        // Assert
        deleteResponseModel.Should().NotBeNull();
        deleteResponseModel.Result.Should().BeNull();
        deleteResponseModel.IsOperationSuccessful.Should().BeTrue();

        SourceFormatNodeGetAllRequestModel getAllRequestModel = new SourceFormatNodeGetAllRequestModel.Builder()
            .Build();
        SourceFormatNodeGetAllResponseModel getAllResponseModel = await SourceFormatsSdk.SourceFormatNode
            .GetAllAsync(getAllRequestModel).ConfigureAwait(false);
        getAllResponseModel.Should().NotBeNull();
        getAllResponseModel.Result.Should().NotBeNull();
        getAllResponseModel.Result.Should().BeOfType<List<SourceFormatNodeDto>>();
        getAllResponseModel.Result.Count.Should().Be(0);
    }

    [Fact]
    public async Task Return_404_WhenEntityDoesNotExistInTheDatabase()
    {
        // Act
        SourceFormatNodeDeleteRequestModel deleteRequestModel = new SourceFormatNodeDeleteRequestModel.Builder()
            .SetId(100)
            .Build();
        SourceFormatNodeDeleteResponseModel deleteResponseModel = await SourceFormatsSdk.SourceFormatNode
            .DeleteAsync(deleteRequestModel).ConfigureAwait(false);

        // Assert
        deleteResponseModel.Should().NotBeNull();
        deleteResponseModel.Message
            .Substring(1, deleteResponseModel.Message.Length - 2)
            .Should().Be(SourceFormatsServiceResultStatuses.NoSuchEntity);
        deleteResponseModel.Result.Should().BeNull();
        deleteResponseModel.IsOperationSuccessful.Should().BeFalse();
    }
}