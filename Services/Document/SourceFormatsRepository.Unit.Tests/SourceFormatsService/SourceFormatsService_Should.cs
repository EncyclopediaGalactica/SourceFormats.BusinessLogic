namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Unit.Tests.SourceFormatsService;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Ctx;
using Document;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using SourceFormats.SourceFormatsRepository.SourceFormatNode;
using Utils.GuardsService;
using ValidatorService;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SourceFormatsService_Should
{
    public static IEnumerable<object[]> Throw_ArgumentNullException_WhenInjectedIsNull_Data = new List<object[]>
    {
        new[] { null, new DocumentRepository(
            new DbContextOptions<SourceFormatsDbContext>(),
            new DocumentValidator()) },
        new[]
        {
            new SourceFormatNodeRepository(
                new DbContextOptions<SourceFormatsDbContext>(),
                new SourceFormatNodeValidator(),
                new GuardsService()),
            null
        },
        new object[] { null, null }
    };

    [Theory]
    [MemberData(nameof(Throw_ArgumentNullException_WhenInjectedIsNull_Data))]
    public void Throw_ArgumentNullException_WhenInjectedIsNull(
        ISourceFormatNodeRepository sourceFormatNodeRepository,
        IDocumentsRepository documentsRepository)
    {
        // Assert
        Action a = () => { new SourceFormatsRepository(sourceFormatNodeRepository, documentsRepository); };
    }
}