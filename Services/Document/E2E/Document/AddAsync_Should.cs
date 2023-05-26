namespace EncyclopediaGalactica.SourceFormats.E2E.Document;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using QA.Datasets;
using Sdk.Models.Document;
using Xunit;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public partial class DocumentSdk_Should
{
    [Fact]
    public async Task Return_201_AndTheCreatedObject()
    {
        // Arrange
        string name = "name";
        string desc = "desc";
        Uri uri = new Uri("https://bla.com");

        DocumentAddRequestModel model = new DocumentAddRequestModel.Builder()
            .SetName(name)
            .SetDescription(desc)
            .SetUri(uri)
            .Build();

        // Act
        DocumentAddResponseModel result = await SourceFormatsSdk.DocumentsSdk.AddAsync(model).ConfigureAwait(false);

        // Assert
        result.Result.Should().NotBeNull();
        result.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        result.IsOperationSuccessful.Should().BeTrue();
        result.Result.Id.Should().BeGreaterThan(0);
        result.Result.Name.Should().Be(name);
        result.Result.Description.Should().Be(desc);
        result.Result.Uri.Should().Be(uri);
    }

    [Fact]
    public async Task Return_400_WhenUniqueNameConstraintIsViolated_ByAdd()
    {
        // Arrange
        DocumentAddRequestModel model = new DocumentAddRequestModel.Builder()
            .SetName("name")
            .SetDescription("desc")
            .SetUri(new Uri("https://bla.com"))
            .Build();

        DocumentAddResponseModel result = await SourceFormatsSdk.DocumentsSdk.AddAsync(model).ConfigureAwait(false);

        DocumentAddRequestModel model2 = new DocumentAddRequestModel.Builder()
            .SetName("name")
            .SetDescription("desc2")
            .SetUri(new Uri("https://bla2.com"))
            .Build();

        // Act
        DocumentAddResponseModel result2 = await SourceFormatsSdk.DocumentsSdk.AddAsync(model2).ConfigureAwait(false);

        // Assert
        result2.Result.Should().BeNull();
        result2.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
        result2.IsOperationSuccessful.Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(DocumentDataset.Add_Validation), MemberType = typeof(DocumentDataset))]
    public void Throw_ValidationException_WhenTheUserCreatesInvalidDocumentObject(
        long id,
        string name,
        string desc,
        Uri uri)
    {
        // Arrange && Act
        Func<Task> f = async () =>
        {
            DocumentAddRequestModel model = new DocumentAddRequestModel.Builder()
                .SetName(name)
                .SetDescription(desc)
                .SetUri(uri)
                .Build();
        };

        // Assert
        f.Should().ThrowExactlyAsync<ValidationException>();
    }
}