namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;
using Microsoft.EntityFrameworkCore.Storage;

public partial class SourceFormatNodeRepository
{
    /// <inheritdoc />
    public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        await using (IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync
                         (cancellationToken).ConfigureAwait(false))
        {
            try
            {
                _guards.NotNull(id);
                _guards.IsNotEqual(id, 0);

                List<SourceFormatNode> toBeDelete = await GetByIdWithFlatTreeAsync(id, ctx, cancellationToken)
                    .ConfigureAwait(false);

                if (toBeDelete.Any())
                {
                    ctx.SourceFormatNodes.RemoveRange(toBeDelete);
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                // logging comes here
                await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                throw;
            }
        }
    }
}