namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.SourceFormatNode;

using Ctx;
using Entities;
using Microsoft.EntityFrameworkCore;

public partial class SourceFormatNodeRepository
{
    /// <inheritdoc />
    public async Task<List<SourceFormatNode>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await using SourceFormatsDbContext ctx = new SourceFormatsDbContext(_dbContextOptions);
        try
        {
            return await ctx.SourceFormatNodes.ToListAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            // logging comes here
            throw;
        }
    }
}