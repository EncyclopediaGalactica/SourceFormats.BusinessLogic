namespace EncyclopediaGalactica.SourceFormats.E2E.SourceFormatNode;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos;
using FluentAssertions;
using Sdk.Models.SourceFormatNode;
using SourceFormatsService.Interfaces;
using Xunit;

public partial class SourceFormatNodeSdk_Should
{
    [Fact]
    public async Task Return_201_AndListOfEntities_WhenThereIsOnlyOneEntityInTheDatabase()
    {
        // Arrange
        SourceFormatNodeAddRequestModel addRequestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("add")
            .Build();
        SourceFormatNodeAddResponseModel addResponseModel = await SourceFormatsSdk.SourceFormatNode
            .AddAsync(addRequestModel).ConfigureAwait(false);

        SourceFormatNodeGetAllRequestModel requestModel = new SourceFormatNodeGetAllRequestModel.Builder()
            .Build();

        // Act
        SourceFormatNodeGetAllResponseModel responseModel = await SourceFormatsSdk.SourceFormatNode
            .GetAllAsync(requestModel).ConfigureAwait(false);

        // Assert
        responseModel.Should().NotBeNull();
        responseModel.Result.Should().NotBeNull();
        responseModel.Result.Should().BeOfType<List<SourceFormatNodeDto>>();
        responseModel.Result?.Count.Should().Be(1);
        responseModel.IsOperationSuccessful.Should().BeTrue();

        responseModel.Result?.First().Name.Should().Be(addRequestModel.Payload?.Name);
    }

    [Fact]
    public async Task Return_201_AndListOfEntities_WhenThereAreTwoEntitiesInTheDatabase()
    {
        // Arrange
        SourceFormatNodeAddRequestModel add1RequestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("add1")
            .Build();
        SourceFormatNodeAddResponseModel add1ResponseModel = await SourceFormatsSdk.SourceFormatNode
            .AddAsync(add1RequestModel).ConfigureAwait(false);

        SourceFormatNodeAddRequestModel add2RequestModel = new SourceFormatNodeAddRequestModel.Builder()
            .SetName("add2")
            .Build();
        SourceFormatNodeAddResponseModel add2ResponseModel = await SourceFormatsSdk.SourceFormatNode
            .AddAsync(add2RequestModel).ConfigureAwait(false);

        SourceFormatNodeGetAllRequestModel requestModel = new SourceFormatNodeGetAllRequestModel.Builder()
            .Build();

        // Act
        SourceFormatNodeGetAllResponseModel responseModel = await SourceFormatsSdk.SourceFormatNode
            .GetAllAsync(requestModel).ConfigureAwait(false);

        // Assert
        responseModel.Should().NotBeNull();
        responseModel.Result.Should().NotBeNull();
        responseModel.Result.Should().BeOfType<List<SourceFormatNodeDto>>();
        responseModel.Result?.Count.Should().Be(2);
        responseModel.IsOperationSuccessful.Should().BeTrue();

        responseModel.Result?.Where(p => p.Name == add1RequestModel.Payload?.Name).ToList().Count.Should().Be(1);
        responseModel.Result?.Where(p => p.Name == add2RequestModel.Payload?.Name).ToList().Count.Should().Be(1);
    }

    [Fact]
    public async Task Return_201_AndEmptyListWhenNoEntitiesInTheDatabase()
    {
        // Arrange
        SourceFormatNodeGetAllRequestModel requestModel = new SourceFormatNodeGetAllRequestModel.Builder()
            .Build();

        // Act
        SourceFormatNodeGetAllResponseModel responseModel = await SourceFormatsSdk.SourceFormatNode
            .GetAllAsync(requestModel).ConfigureAwait(false);

        // Assert
        responseModel.Should().NotBeNull();
        responseModel.Result.Should().NotBeNull();
        responseModel.Result.Should().BeOfType<List<SourceFormatNodeDto>>();
        responseModel.Result?.Count.Should().Be(0);
        responseModel.IsOperationSuccessful.Should().BeTrue();
    }
}