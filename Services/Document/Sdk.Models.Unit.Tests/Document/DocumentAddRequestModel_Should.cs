namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.Document;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Models.Document;
using QA.Datasets;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class DocumentAddRequestModel_Should
{
    [Fact]
    public void Populate_Model()
    {
        // Arrange && Act
        long id = 100;
        string name = "name";
        string desc = "desc";
        Uri uri = new Uri("https://bla.com");

        DocumentAddRequestModel model = new DocumentAddRequestModel.Builder()
            .SetName(name)
            .SetDescription(desc)
            .SetUri(uri)
            .AddAcceptHeader("application/json")
            .Build();

        // Assert
        model.Payload.Should().NotBeNull();
        model.Payload.Name.Should().Be(name);
        model.Payload.Description.Should().Be(desc);
        model.Payload.Uri.Should().Be(uri);
        model.AcceptHeaders.Should().NotBeNull();
        model.AcceptHeaders.Count.Should().Be(1);
    }

    [Theory]
    [MemberData(nameof(DocumentDataset.Add_Validation), MemberType = typeof(DocumentDataset))]
    public void Throw_ValidationException_WhenTheCreatedObjectIsInvalid(
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