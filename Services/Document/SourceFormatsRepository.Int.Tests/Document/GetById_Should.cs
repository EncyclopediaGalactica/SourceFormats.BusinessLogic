namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Int.Tests.Document;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Entities;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class GetById_Should : BaseTest
{
    [Fact]
    public async Task Return_WithTheDesignatedEntity()
    {
        // Arrange
        string name = "name";
        string desc = "desc";
        Document data = await Sut.Documents.AddAsync(new Document
        {
            Name = name,
            Description = desc
        }).ConfigureAwait(false);

        // Act
        Document result = await Sut.Documents.GetByIdAsync(data.Id).ConfigureAwait(false);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThan(0);
        result.Name.Should().Be(name);
        result.Description.Should().Be(desc);
    }

    [Fact]
    public void Throw_InvalidOperationException_WhenNoSuchEntity()
    {
        // Arrange && Act
        Func<Task> f = async () =>
        {
            await Sut.Documents.GetByIdAsync(100).ConfigureAwait(false);
        };

        // Assert
        f.Should().ThrowExactlyAsync<InvalidOperationException>();
    }
}