namespace EncyclopediaGalactica.SourceFormats.E2E.SourceFormatNode;

using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using Sdk.Models.SourceFormatNode;
using SourceFormatsService.Interfaces;
using Xunit;

public partial class SourceFormatNodeSdk_Should
{
    [Fact]
    public async Task Return_201_WithEntityDetails_AndOperationDetails()
    {
        // Arrange
        SourceFormatNodeAddRequestModel addRequestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("asd")
            .Build();
        SourceFormatNodeAddResponseModel addResponseModel = await SourceFormatsSdk.SourceFormatNode
            .AddAsync(addRequestModel).ConfigureAwait(false);

        // Act
        SourceFormatNodeGetByIdRequestModel getByIdRequestModel = new SourceFormatNodeGetByIdRequestModel.Builder()
            .SetId(addResponseModel.Result.Id)
            .Build();
        SourceFormatNodeGetByIdResponseModel getByIdResponseModel = await SourceFormatsSdk.SourceFormatNode
            .GetByIdAsync(getByIdRequestModel).ConfigureAwait(false);

        // Assert
        getByIdResponseModel.Should().NotBeNull();
        getByIdResponseModel.Should().BeOfType<SourceFormatNodeGetByIdResponseModel>();
        getByIdResponseModel.Result.Should().NotBeNull();
        getByIdResponseModel.Result.Should().BeOfType<SourceFormatNodeDto>();
        getByIdResponseModel.IsOperationSuccessful.Should().BeTrue();
    }

    public async Task Return_404_WhenNoSuchEntity()
    {
        // Act
        SourceFormatNodeGetByIdRequestModel getByIdRequestModel = new SourceFormatNodeGetByIdRequestModel.Builder()
            .SetId(100)
            .Build();
        SourceFormatNodeGetByIdResponseModel getByIdResponseModel = await SourceFormatsSdk.SourceFormatNode
            .GetByIdAsync(getByIdRequestModel).ConfigureAwait(false);

        // Assert
        getByIdResponseModel.Should().NotBeNull();
        getByIdResponseModel.Should().BeOfType<SourceFormatNodeGetByIdResponseModel>();
        getByIdResponseModel.Message.Should().NotBeNull();
        getByIdResponseModel.Message.Should().Be(SourceFormatsServiceResultStatuses.NoSuchEntity);
        getByIdResponseModel.Result.Should().BeNull();
        getByIdResponseModel.IsOperationSuccessful.Should().BeFalse();
    }
}