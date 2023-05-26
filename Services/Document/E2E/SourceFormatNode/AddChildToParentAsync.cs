namespace EncyclopediaGalactica.SourceFormats.E2E.SourceFormatNode;

using System;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using QA.Datasets;
using Sdk.Models;
using Sdk.Models.SourceFormatNode;
using SourceFormatsService.Interfaces;
using Xunit;

public partial class SourceFormatNodeSdk_Should
{
    [Theory]
    [MemberData(nameof(QA.Datasets.SourceFormatNodeDatasets.SDKModels_AddChildToParent_InputValidation_Dataset),
        MemberType = typeof(SourceFormatNodeDatasets))]
    public async Task Throw_WhenTheUserTtriesToBuildRequestModel_BasedOnInvalidInput(
        long childId,
        long parentId)
    {
        // Act
        Action action = () =>
        {
            SourceFormatNodeAddChildToParentRequestModel requestModel = new
                    SourceFormatNodeAddChildToParentRequestModel.Builder()
                .SetChildrenNodeId(childId)
                .SetParentNodeId(parentId)
                .Build();
        };

        // Assert
        action.Should().ThrowExactly<SdkModelsException>();
    }

    public async Task Return_201_AndAddChildToParent()
    {
        // Arrange
        SourceFormatNodeAddRequestModel rootNodeAddRequestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("root")
            .Build();
        SourceFormatNodeAddResponseModel rootNodeResponseModel = await SourceFormatsSdk.SourceFormatNode
            .AddAsync(rootNodeAddRequestModel).ConfigureAwait(false);

        SourceFormatNodeAddRequestModel parentNodeAddRequestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("parent")
            .Build();
        SourceFormatNodeAddResponseModel parentNodeResponseModel = await SourceFormatsSdk.SourceFormatNode
            .AddAsync(parentNodeAddRequestModel).ConfigureAwait(false);
        SourceFormatNodeAddChildToParentRequestModel addParentToRootNodeRequestModel = new
                SourceFormatNodeAddChildToParentRequestModel.Builder()
            .SetChildrenNodeId(parentNodeResponseModel.Result!.Id)
            .SetParentNodeId(rootNodeResponseModel.Result!.Id)
            .Build();
        SourceFormatNodeAddChildToParentResponseModel addParentToRootNodeResponseModel = await SourceFormatsSdk
            .SourceFormatNode.AddChildToParentAsync(addParentToRootNodeRequestModel).ConfigureAwait(false);

        SourceFormatNodeAddRequestModel childRequestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("child")
            .Build();
        SourceFormatNodeAddResponseModel childResponseModel = await SourceFormatsSdk.SourceFormatNode
            .AddAsync(childRequestModel).ConfigureAwait(false);

        // Act
        SourceFormatNodeAddChildToParentRequestModel addChildToParentResponseModel = new
                SourceFormatNodeAddChildToParentRequestModel.Builder()
            .SetChildrenNodeId(childResponseModel.Result!.Id)
            .SetParentNodeId(addParentToRootNodeResponseModel.Result!.Id)
            .Build();
        SourceFormatNodeAddChildToParentResponseModel responseModel = await SourceFormatsSdk.SourceFormatNode
            .AddChildToParentAsync(addChildToParentResponseModel).ConfigureAwait(false);

        // Assert
        responseModel.Should().NotBeNull();
        responseModel.Should().BeOfType<SourceFormatNodeAddChildToParentResponseModel>();
        responseModel.Result.Should().NotBeNull();
        responseModel.Result.Should().BeOfType<SourceFormatNodeDto>();
        responseModel.Result?.Id.Should().Be(childResponseModel.Result.Id);
        responseModel.IsOperationSuccessful.Should().BeTrue();
        responseModel.Message.Should().NotBeNull();
        responseModel.Message.Should().Be(SourceFormatsServiceResultStatuses.Success);
    }
}