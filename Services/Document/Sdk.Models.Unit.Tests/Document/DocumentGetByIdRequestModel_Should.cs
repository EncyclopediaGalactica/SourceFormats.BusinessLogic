namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.Document;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Models.Document;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class DocumentGetByIdRequestModel_Should
{
    [Fact]
    public void Throw_ValidationException_WhenInvalidRequestModelIsBuilt()
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
    public void Build_TheProperObject()
    {
        // Arrange && Act
        long id = 100;
        DocumentGetByIdRequestModel requestModel = new DocumentGetByIdRequestModel.Builder()
            .SetId(id)
            .Build();

        // Assert
        requestModel.Should().BeOfType<DocumentGetByIdRequestModel>();
        requestModel.Payload.Should().NotBeNull();
        requestModel.Payload.Id.Should().Be(id);
        requestModel.AcceptHeaders.Should().NotBeNull();
    }
}