namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Ctx;
using Entities;
using FluentValidation;
using Interfaces;
using Interfaces.Document;
using Interfaces.SourceFormatNode;
using Mappers;
using Mappers.Document;
using Mappers.Interfaces;
using Mappers.SourceFormatNode;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SourceFormats.SourceFormatsService.Document;
using SourceFormatsCacheService.Interfaces;
using SourceFormatsCacheService.SourceFormatNode;
using SourceFormatsRepository.Document;
using SourceFormatsRepository.Interfaces;
using SourceFormatsRepository.SourceFormatNode;
using Utils.GuardsService;
using ValidatorService;

[ExcludeFromCodeCoverage]
public class BaseTest
{
    protected readonly ISourceFormatsService Sut;

    public BaseTest()
    {
        SqliteConnection connection = new("Filename=:memory:");
        connection.Open();
        SourceFormatNodeDtoValidator validator = new();
        IValidator<SourceFormatNode> nodeValidator = new SourceFormatNodeValidator();
        ISourceFormatNodeMappers sourceFormatNodeMappers = new SourceFormatNodeMappers();
        IDocumentMappers documentMappers = new DocumentMappers();
        ISourceFormatMappers mappers = new SourceFormatMappers(
            sourceFormatNodeMappers,
            documentMappers);

        DbContextOptions<SourceFormatsDbContext> dbContextOptions =
            new DbContextOptionsBuilder<SourceFormatsDbContext>()
                .UseSqlite(connection).LogTo(m => Debug.WriteLine(m)).EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .Options;
        SourceFormatsDbContext ctx = new(dbContextOptions);
        ctx.Database.EnsureCreated();

        ISourceFormatNodeRepository sourceFormatNodeRepository = new SourceFormatNodeRepository(
            dbContextOptions, nodeValidator, new GuardsService());
        ISourceFormatNodeCacheService sourceFormatNodeCacheService = new SourceFormatNodeCacheService();
        ILogger<SourceFormats.SourceFormatsService.SourceFormatNodeService.SourceFormatNodeService> logger =
            new Logger<SourceFormats.SourceFormatsService.SourceFormatNodeService.SourceFormatNodeService>(
                new LoggerFactory());
        ISourceFormatNodeService sourceFormatNodeService =
            new SourceFormats.SourceFormatsService.SourceFormatNodeService.SourceFormatNodeService(
                validator,
                new GuardsService(),
                mappers,
                sourceFormatNodeRepository,
                sourceFormatNodeCacheService,
                logger);

        IValidator<Entities.Document> documentValidator = new DocumentValidator();
        IDocumentsRepository documentsRepository = new DocumentRepository(
            dbContextOptions, documentValidator);
        IDocumentService documentService = new DocumentService(
            new GuardsService(),
            mappers,
            documentsRepository);

        Sut = new SourceFormatsService(
            sourceFormatNodeService,
            documentService);
    }
}