namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public partial class SourceFormatNodeRepository
{
    /// <inheritdoc />
    public async Task<List<SourceFormatNode>> GetByIdWithFlatTreeAsync(long id,
        CancellationToken cancellationToken = default)
    {
        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        await using IDbContextTransaction transaction = await ctx.Database.BeginTransactionAsync(cancellationToken)
            .ConfigureAwait(false);
        {
            try
            {
                _guards.IsNotEqual(id, 0);
                List<SourceFormatNode> nodeList = await GetByIdWithFlatTreeAsync(id, ctx, cancellationToken)
                    .ConfigureAwait(false);
                await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
                return nodeList;
            }
            catch (Exception e)
            {
                // logging comes here
                await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                throw;
            }
        }
    }

    private async Task<List<SourceFormatNode>> GetByIdWithFlatTreeAsync(
        long id,
        SourceFormatsDbContext ctx,
        CancellationToken cancellationToken = default)
    {
        _guards.IsNotEqual(id, 0);
        ctx.ChangeTracker.Clear();
        SourceFormatNode? startNodeInTree = await ctx.SourceFormatNodes
            .FirstAsync(p => p.Id == id, cancellationToken)
            .ConfigureAwait(false);
        if (startNodeInTree.ChildrenSourceFormatNodes.Any())
            throw new InvalidOperationException(
                $"Entity with id: {id} should not include its children.");

        List<SourceFormatNode> sourceFormatNodes = await ctx.SourceFormatNodes
            .Where(w => w.RootNodeId == startNodeInTree.RootNodeId)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        List<SourceFormatNode> result = GetFlatTree(startNodeInTree, sourceFormatNodes);
        return result;
    }

    private List<SourceFormatNode> GetFlatTree(SourceFormatNode node, List<SourceFormatNode> sourceFormatNodes)
    {
        List<SourceFormatNode> result = new List<SourceFormatNode>();

        if (node.ChildrenSourceFormatNodes.Any())
        {
            foreach (SourceFormatNode child in node.ChildrenSourceFormatNodes)
            {
                result.AddRange(GetFlatTree(child, sourceFormatNodes));
            }
        }

        result.Add(node);

        return result;
    }
}