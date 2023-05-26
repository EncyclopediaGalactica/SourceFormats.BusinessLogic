namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Storage;
using ValidatorService;

public partial class SourceFormatNodeRepository
{
    /// <inheritdoc />
    public async Task<SourceFormatNode> AddAsync(
        SourceFormatNode node,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(node);
        await ValidateInputNodeForAddingAsync(node, cancellationToken).ConfigureAwait(false);

        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        await using (IDbContextTransaction transaction = await ctx.Database
                         .BeginTransactionAsync(cancellationToken).ConfigureAwait(false))
        {
            try
            {
                await ctx.SourceFormatNodes.AddAsync(node, cancellationToken);
                await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception te)
            {
                // add logging here
                await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                throw;
            }
        }

        return node;
    }

    private async Task ValidateInputNodeForAddingAsync(SourceFormatNode node, CancellationToken cancellationToken)
    {
        await _sourceFormatNodeValidator.ValidateAsync(node, o =>
            {
                o.IncludeRuleSets(SourceFormatNodeValidator.Add);
                o.ThrowOnFailures();
            }, cancellationToken)
            .ConfigureAwait(false);
    }
}