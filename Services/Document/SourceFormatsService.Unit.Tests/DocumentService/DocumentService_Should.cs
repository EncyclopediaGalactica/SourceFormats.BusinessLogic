namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Unit.Tests.DocumentService;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Ctx;
using Document;
using Entities;
using FluentAssertions;
using FluentValidation;
using Mappers;
using Mappers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using SourceFormatsRepository.Document;
using SourceFormatsRepository.Interfaces;
using Utils.GuardsService;
using Utils.GuardsService.Interfaces;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class DocumentService_Should
{
    public static IEnumerable<object[]> ThrowArgumentNullException_WhenInjected_IsNull_Data = new List<object[]>
    {
        new object[]
        {
            null,
            new SourceFormatMappers(
                new Mock<ISourceFormatNodeMappers>().Object,
                new Mock<IDocumentMappers>().Object),
            new DocumentRepository(
                new DbContextOptions<SourceFormatsDbContext>(),
                new Mock<IValidator<Document>>().Object)
        },
        new object[]
        {
            new GuardsService(),
            null,
            new DocumentRepository(
                new DbContextOptions<SourceFormatsDbContext>(),
                new Mock<IValidator<Document>>().Object)
        },
        new object[]
        {
            new GuardsService(),
            new SourceFormatMappers(
                new Mock<ISourceFormatNodeMappers>().Object,
                new Mock<IDocumentMappers>().Object),
            null
        }
    };

    [Theory]
    [MemberData(nameof(ThrowArgumentNullException_WhenInjected_IsNull_Data))]
    public void ThrowArgumentNullException_WhenInjected_IsNull(
        IGuardsService guardsService,
        ISourceFormatMappers mappers,
        IDocumentsRepository documentsRepository)
    {
        // Arrange && Act
        Action action = () =>
        {
            new DocumentService(
                guardsService,
                mappers,
                documentsRepository);
        };

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }
}