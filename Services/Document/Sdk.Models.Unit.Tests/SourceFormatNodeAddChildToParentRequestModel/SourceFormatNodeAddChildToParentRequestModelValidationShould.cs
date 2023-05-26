namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.SourceFormatNodeAddChildToParentRequestModel;

using System;
using FluentAssertions;
using QA.Datasets;
using SourceFormatNode;
using Xunit;

public class SourceFormatNodeAddChildToParentRequestModelValidationShould
{
    [Theory]
    [MemberData(nameof(QA.Datasets.SourceFormatNodeDatasets.SDKModels_AddChildToParent_InputValidation_Dataset),
        MemberType = typeof(SourceFormatNodeDatasets))]
    public void Throw_WhenUserTriesToBuildRequestModel_WithInvalidInput(
        long childId, long parentId)
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
        action.Should().Throw<SdkModelsException>();
    }
}