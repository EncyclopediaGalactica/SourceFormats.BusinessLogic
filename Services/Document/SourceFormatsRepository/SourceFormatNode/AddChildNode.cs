namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public partial class SourceFormatNodeRepository
{
    /// <inheritdoc />
    public async Task<SourceFormatNode> AddChildNodeAsync(
        long childId,
        long parentId,
        long rootNodeId,
        CancellationToken cancellationToken = default)
    {
        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        await using (IDbContextTransaction transaction = await ctx.Database
                         .BeginTransactionAsync(cancellationToken).ConfigureAwait(false))
            try
            {
                CheckInputForAddChildNode(childId, parentId, rootNodeId);

                SourceFormatNode? child = await ctx.SourceFormatNodes
                    .FirstAsync(p => p.Id == childId, cancellationToken)
                    .ConfigureAwait(false);
                SourceFormatNode? parent = await ctx.SourceFormatNodes
                    .Include(i => i.ChildrenSourceFormatNodes)
                    .Include(ii => ii.RootNode)
                    .FirstAsync(p => p.Id == parentId, cancellationToken)
                    .ConfigureAwait(false);

                // if the parent node does not have a root node, we assume that building the tree is at its first step
                // so makes sense to make the parent to a root node
                // NOTE: possibly this is not the best solution, but will do it until the whole turns out
                if (parent.RootNode is null)
                {
                    parent.IsRootNode = 1;
                    parent.RootNodeId = parent.Id;
                    ctx.Entry(parent).State = EntityState.Modified;
                    await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    parent = await ctx.SourceFormatNodes
                        .Include(i => i.ChildrenSourceFormatNodes)
                        .Include(ii => ii.RootNode)
                        .FirstAsync(p => p.Id == parentId, cancellationToken)
                        .ConfigureAwait(false);
                }

                if (parent.ChildrenSourceFormatNodes.Contains(child))
                {
                    // logging here
                    throw new InvalidOperationException(
                        $"Node with id: {child.Id} is already added to parent with id: {parent.Id}");
                }

                child.ParentNodeId = parent.Id;
                child.RootNodeId = parent.RootNode.Id;
                ctx.Entry(child).State = EntityState.Modified;
                await ctx.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
                return child;
            }
            catch (Exception e)
            {
                // add logging here
                await transaction.RollbackAsync(cancellationToken).ConfigureAwait(false);
                throw;
            }
    }

    private void CheckInputForAddChildNode(long childId, long parentId, long rootNodeId)
    {
        _guards.IsNotEqual(childId, 0);
        _guards.IsNotEqual(parentId, 0);
        _guards.IsNotEqual(rootNodeId, 0);
        _guards.IsNotEqual(childId, parentId);
        _guards.IsNotEqual(childId, rootNodeId);
    }
}