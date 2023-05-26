namespace EncyclopediaGalactica.SourceFormats.Entities.Unit.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class DocumentProperties_Should
{
    [Fact]
    public void Id_NotChange()
    {
        // Arrange && Act
        long docId = 100L;
        Document document = new Document { Id = docId };

        // Assert
        document.Id.Should().Be(docId);
    }

    [Fact]
    public void Name_DontChange()
    {
        // Arrange && Act
        string name = "asd";
        Document document = new Document { Name = name };

        // Assert
        document.Name.Should().Be(name);
    }

    [Fact]
    public void Description_DontChange()
    {
        // Arrange && Act
        string desc = "description";
        Document document = new Document { Description = desc };

        // Assert
        document.Description.Should().Be(desc);
    }

    [Fact]
    public void Uri_DontChange()
    {
        // Arrange && Act
        Uri uri = new Uri("https://asd.com");
        Document document = new Document { Uri = uri };

        // Assert
        document.Uri.Should().Be(uri);
    }
}