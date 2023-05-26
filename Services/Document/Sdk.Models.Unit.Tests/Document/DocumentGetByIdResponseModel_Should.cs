namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.Unit.Tests.Document;

using System.Diagnostics.CodeAnalysis;
using System.Net;
using Dtos;
using FluentAssertions;
using Models.Document;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class DocumentGetByIdResponseModel_Should
{
    [Fact]
    public void SetAndGetProperties_WithoutAnyChanges()
    {
        // Arrange
        HttpStatusCode httpStatusCode = HttpStatusCode.Accepted;
        bool isOperationSuccessful = true;
        string message = "message";
        DocumentDto documentDto = new DocumentDto();

        // Act
        DocumentAddResponseModel model = new DocumentAddResponseModel
        {
            HttpStatusCode = httpStatusCode,
            IsOperationSuccessful = isOperationSuccessful,
            Message = message,
            Result = documentDto
        };

        // Assert
        model.HttpStatusCode.Should().Be(httpStatusCode);
        model.IsOperationSuccessful.Should().Be(isOperationSuccessful);
        model.Message.Should().Be(message);
        model.Result.Should().Be(documentDto);
    }

    [Fact]
    public void SetAndGetProperties_WithoutAnyChanges_NullableProperties()
    {
        // Arrange
        HttpStatusCode httpStatusCode = HttpStatusCode.Accepted;
        bool isOperationSuccessful = true;
        string message = "message";

        // Act
        DocumentAddResponseModel model = new DocumentAddResponseModel
        {
            HttpStatusCode = httpStatusCode,
            IsOperationSuccessful = isOperationSuccessful,
            Message = message
        };

        // Assert
        model.HttpStatusCode.Should().Be(httpStatusCode);
        model.IsOperationSuccessful.Should().Be(isOperationSuccessful);
        model.Message.Should().Be(message);
        model.Result.Should().BeNull();
    }
}