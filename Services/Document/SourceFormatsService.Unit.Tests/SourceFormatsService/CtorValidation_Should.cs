namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Unit.Tests.SourceFormatsService;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Ctx;
using Document;
using Entities;
using FluentAssertions;
using Interfaces;
using Interfaces.Document;
using Interfaces.SourceFormatNode;
using Mappers;
using Mappers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SourceFormats.SourceFormatsService.SourceFormatNodeService;
using SourceFormatsCacheService.SourceFormatNode;
using SourceFormatsRepository.Interfaces;
using SourceFormatsRepository.SourceFormatNode;
using Utils.GuardsService;
using ValidatorService;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class CtorValidation_Should
{
    public static IEnumerable<object[]> Throw_WhenAnyCtorParamIsNull_Data => new List<object[]>
    {
        new[]
        {
            null,
            new DocumentService(new GuardsService(),
                new SourceFormatMappers(
                    new Mock<ISourceFormatNodeMappers>().Object,
                    new Mock<IDocumentMappers>().Object),
                new Mock<IDocumentsRepository>().Object)
        },
        new object[] { null!, null! },
        new[]
        {
            new SourceFormatNodeService(
                new SourceFormatNodeDtoValidator(),
                new GuardsService(),
                new SourceFormatMappers(
                    new Mock<ISourceFormatNodeMappers>().Object,
                    new Mock<IDocumentMappers>().Object),
                new SourceFormatNodeRepository(
                    new DbContextOptions<SourceFormatsDbContext>(),
                    new SourceFormatNodeValidator(),
                    new GuardsService()),
                new SourceFormatNodeCacheService(),
                new Mock<ILogger<SourceFormatNodeService>>().Object),
            null
        },
    };

    [Theory]
    [MemberData(nameof(Throw_WhenAnyCtorParamIsNull_Data))]
    public void Throw_WhenAnyCtorParamIsNull(
        ISourceFormatNodeService sourceFormatNodeService,
        IDocumentService documentService)
    {
        // Arrange & Act
        Action action = () =>
        {
            ISourceFormatsService sourceFormatsService = new SourceFormats.SourceFormatsService.SourceFormatsService(
                sourceFormatNodeService,
                documentService);
        };

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }
}