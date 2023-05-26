namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Document;

using Ctx;
using Entities;
using FluentValidation;
using ValidatorService;

public partial class DocumentRepository
{
    /// <inheritdoc />
    public async Task<Document> AddAsync(Document document, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(document);
        await ValidateAddAsyncInput(document, cancellationToken).ConfigureAwait(false);
        Document result = await AddDatabaseOperationAsync(document, cancellationToken)
            .ConfigureAwait(false);
        return result;
    }

    private async Task<Document> AddDatabaseOperationAsync(Document document, CancellationToken cancellationToken)
    {
        await using (SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions))
        {
            await ctx.AddAsync(document, cancellationToken).ConfigureAwait(false);
            await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return document;
        }
    }

    private async Task ValidateAddAsyncInput(Document document, CancellationToken cancellationToken)
    {
        await _documentValidator.ValidateAsync(document, o =>
            {
                o.IncludeRuleSets(Operations.Add);
                o.ThrowOnFailures();
            }, cancellationToken)
            .ConfigureAwait(false);
    }
}