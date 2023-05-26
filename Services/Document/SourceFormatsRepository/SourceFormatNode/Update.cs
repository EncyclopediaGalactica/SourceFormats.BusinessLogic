namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ValidatorService;

public partial class SourceFormatNodeRepository
{
    /// <inheritdoc />
    public async Task<SourceFormatNode> UpdateAsync(
        SourceFormatNode node,
        CancellationToken cancellationToken = default)
    {
        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        await using (IDbContextTransaction transaction = await ctx.Database
                         .BeginTransactionAsync(cancellationToken).ConfigureAwait(false))
        {
            try
            {
#pragma warning disable CA1062
                await ValidateInputForUpdatingAsync(node, cancellationToken).ConfigureAwait(false);
                SourceFormatNode? toBeUpdated = await ctx.SourceFormatNodes
                    .FirstAsync(p => p.Id == node.Id, cancellationToken)
                    .ConfigureAwait(false);
#pragma warning restore CA1062

                MapNewValuesToEntity(node, toBeUpdated);
                ctx.Entry(toBeUpdated).State = EntityState.Modified;
                await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
                return toBeUpdated;
            }
            catch (Exception e)
            {
                // logging comes here
                await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                throw;
            }
        }
    }

    private static void MapNewValuesToEntity(SourceFormatNode node, SourceFormatNode toBeUpdated)
    {
        toBeUpdated.Name = node.Name;
        toBeUpdated.IsRootNode = node.IsRootNode;
        toBeUpdated.ParentNodeId = node.ParentNodeId;
        toBeUpdated.RootNodeId = node.RootNodeId;
    }

    private async Task ValidateInputForUpdatingAsync(SourceFormatNode node, CancellationToken cancellationToken)
    {
        await _sourceFormatNodeValidator.ValidateAsync(node, o =>
        {
            o.IncludeRuleSets(SourceFormatNodeValidator.Update);
            o.ThrowOnFailures();
        }, cancellationToken).ConfigureAwait(false);
    }
}