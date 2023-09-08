namespace EncyclopediaGalactica.Services.Document.SourceFormatsService.Tests.Int.Document;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dtos;
using Exceptions;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[Trait("Category", "DocumentService")]
public class Add_Should : BaseTest
{
    [Fact]
    public async Task Throw_DbUpdateException_WhenNameUniqueConstraint_IsViolated()
    {
        // Arrange
        string name = "name";
        DocumentDto first = new DocumentDto
        {
            Name = name,
            Description = "desc"
        };

        DocumentDto firstResult = await Sut.DocumentService.AddAsync(first).ConfigureAwait(false);

        // Act
        Func<Task> f = async () =>
        {
            await Sut.DocumentService.AddAsync(new DocumentDto { Name = name, Description = "desc" })
                .ConfigureAwait(false);
        };

        // Assert
        await f.Should().ThrowExactlyAsync<InvalidInputToDocumentServiceException>().ConfigureAwait(false);
    }

    [Fact]
    public async Task Add_Entity_AndReturnTheNewOne()
    {
        // Arrange
        DocumentDto first = new DocumentDto
        {
            Name = "name",
            Description = "desc"
        };

        // Act
        DocumentDto result = await Sut.DocumentService.AddAsync(first).ConfigureAwait(false);

        // Assert
        result.Id.Should().BeGreaterThan(0);
        result.Name.Should().Be(first.Name);
        result.Description.Should().Be(first.Description);
        result.Uri.Should().BeNull();
    }
}