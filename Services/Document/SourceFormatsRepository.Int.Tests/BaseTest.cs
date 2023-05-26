namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Int.Tests;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Ctx;
using Document;
using Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SourceFormats.SourceFormatsRepository.Document;
using SourceFormats.SourceFormatsRepository.SourceFormatNode;
using Utils.GuardsService;
using ValidatorService;

[ExcludeFromCodeCoverage]
public class BaseTest
{
#pragma warning disable CA1051
    protected readonly ISourceFormatsRepository Sut;
#pragma warning restore CA1051

    public BaseTest()
    {
        SqliteConnection connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        DbContextOptions<SourceFormatsDbContext> sourceFormatsDbContextOptions = new
                DbContextOptionsBuilder<SourceFormatsDbContext>()
            .UseSqlite(connection)
            .LogTo(m => Debug.WriteLine(m)).EnableSensitiveDataLogging().EnableDetailedErrors()
            .Options;
        SourceFormatsDbContext ctx = new SourceFormatsDbContext(sourceFormatsDbContextOptions);
        ctx.Database.EnsureCreated();

        ISourceFormatNodeRepository sourceFormatNodeRepository = new SourceFormatNodeRepository(
            sourceFormatsDbContextOptions,
            new SourceFormatNodeValidator(),
            new GuardsService());
        IDocumentsRepository documentsRepository = new DocumentRepository(
            sourceFormatsDbContextOptions,
            new DocumentValidator());
        Sut = new SourceFormatsRepository(
            sourceFormatNodeRepository,
            documentsRepository);
    }

    protected async Task<(
        int childCount,
        long childId,
        long parentId,
        long rootNodeId)> PrepareSourceFormatNodeRepoWith_OneParentAnd_OneChild()
    {
        Entities.SourceFormatNode parent = await Sut.SourceFormatNodes.AddAsync(
            new Entities.SourceFormatNode("parent")).ConfigureAwait(false);
        Entities.SourceFormatNode child = await Sut.SourceFormatNodes.AddAsync(
            new Entities.SourceFormatNode("child1")).ConfigureAwait(false);

        Entities.SourceFormatNode result = await Sut.SourceFormatNodes.AddChildNodeAsync(
            child.Id,
            parent.Id,
            parent.Id).ConfigureAwait(false);
        (int, long, long, long) res = (
            1,
            child.Id,
            parent.Id,
            parent.Id);
        return res;
    }
}