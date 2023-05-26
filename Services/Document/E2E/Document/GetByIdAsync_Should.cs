namespace EncyclopediaGalactica.SourceFormats.E2E.Document;

using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Sdk.Models.Document;
using Xunit;

public partial class DocumentSdk_Should
{
    [Fact]
    public void Throw_ValidationException_WhenInputRequestModelIsBeingBuilt()
    {
        // Arrange && Act
        Action action = () =>
        {
            new DocumentGetByIdRequestModel.Builder()
                .SetId(0)
                .Build();
        };

        // Assert
        action.Should().ThrowExactly<ValidationException>();
    }

    [Fact]
    public async Task Return_200_WithTheDesignatedEntity()
    {
        // Arrange
        string name = "name";
        string desc = "desc";
        DocumentAddRequestModel addRequestModel = new DocumentAddRequestModel.Builder()
            .SetName(name)
            .SetDescription(desc)
            .Build();
        DocumentAddResponseModel addResult = await SourceFormatsSdk.DocumentsSdk.AddAsync(addRequestModel)
            .ConfigureAwait(false);

        DocumentGetByIdRequestModel getByIdRequestModel = new DocumentGetByIdRequestModel.Builder()
            .SetId(addResult.Result.Id)
            .Build();

        // Act
        DocumentGetByIdResponseModel getByIdResponseModel = await SourceFormatsSdk.DocumentsSdk
            .GetByIdAsync(getByIdRequestModel).ConfigureAwait(false);

        // Assert
        getByIdResponseModel.Should().NotBeNull();
        getByIdResponseModel.Result.Should().NotBeNull();
        getByIdResponseModel.Result.Id.Should().BeGreaterThan(0);
        getByIdResponseModel.Result.Name.Should().Be(name);
        getByIdResponseModel.Result.Description.Should().Be(desc);
        getByIdResponseModel.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        getByIdResponseModel.IsOperationSuccessful.Should().BeTrue();
    }

    [Fact]
    public async Task Return_404_WhenNoSuchEntity()
    {
        // Arrange
        DocumentGetByIdRequestModel getByIdRequestModel = new DocumentGetByIdRequestModel.Builder()
            .SetId(100)
            .Build();

        // Act
        DocumentGetByIdResponseModel getByIdResponseModel = await SourceFormatsSdk.DocumentsSdk
            .GetByIdAsync(getByIdRequestModel).ConfigureAwait(false);

        // Assert
        getByIdResponseModel.Should().NotBeNull();
        getByIdResponseModel.Result.Should().BeNull();
        getByIdResponseModel.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
        getByIdResponseModel.IsOperationSuccessful.Should().BeFalse();
    }
}