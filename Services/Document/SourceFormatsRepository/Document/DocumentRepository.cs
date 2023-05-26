namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Document;

using Ctx;
using Entities;
using FluentValidation;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using ValidatorService;

/// <inheritdoc />
public partial class DocumentRepository : IDocumentsRepository
{
    private readonly DbContextOptions<SourceFormatsDbContext> _dbContextOptions;
    private readonly IValidator<Document> _documentValidator;

    public DocumentRepository(
        DbContextOptions<SourceFormatsDbContext> dbContextOptions,
        IValidator<Document> documentValidator)
    {
        ArgumentNullException.ThrowIfNull(dbContextOptions);
        ArgumentNullException.ThrowIfNull(documentValidator);

        _dbContextOptions = dbContextOptions;
        _documentValidator = documentValidator;
    }

    /// <inheritdoc />
    public async Task<List<Document>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}