namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Document;

using Ctx;
using Entities;

public partial class DocumentRepository
{
    /// <inheritdoc />
    public async Task<Document> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        Document? result = await ctx.Documents.FindAsync(id, cancellationToken).ConfigureAwait(false);

        if (result is null)
            throw new InvalidOperationException("No such entity.");

        return result;
    }
}