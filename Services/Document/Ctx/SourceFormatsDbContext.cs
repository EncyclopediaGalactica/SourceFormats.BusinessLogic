namespace EncyclopediaGalactica.SourceFormats.Ctx;

using Entities;
using Microsoft.EntityFrameworkCore;

public class SourceFormatsDbContext : DbContext
{
    public SourceFormatsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected SourceFormatsDbContext()
    {
    }

    public DbSet<SourceFormatNode> SourceFormatNodes => Set<SourceFormatNode>();
    public DbSet<Document> Documents => Set<Document>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder is null)
            throw new ArgumentNullException(nameof(modelBuilder));

#pragma warning disable CA1062
        modelBuilder.Entity<SourceFormatNode>().ToTable("source_format_node");
        modelBuilder.Entity<SourceFormatNode>().HasKey(k => k.Id);
        modelBuilder.Entity<SourceFormatNode>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<SourceFormatNode>().Property(p => p.Id).HasColumnName("id");
        modelBuilder.Entity<SourceFormatNode>().Property(p => p.Name).HasColumnName("name");
        modelBuilder.Entity<SourceFormatNode>().HasIndex(p => p.Name).IsUnique();
        modelBuilder.Entity<SourceFormatNode>().Property(p => p.IsRootNode)
            .HasColumnName("is_root_node")
            .IsRequired();
        modelBuilder.Entity<SourceFormatNode>().Property(p => p.ParentNodeId).HasColumnName("parent_node_id");
        modelBuilder.Entity<SourceFormatNode>().Property(p => p.RootNodeId)
            .HasColumnName("root_node_id")
            .IsRequired(false);

        modelBuilder.Entity<SourceFormatNode>()
            .HasMany(p => p.ChildrenSourceFormatNodes)
            .WithOne(p => p.ParentSourceFormatNode)
            .HasForeignKey(k => k.ParentNodeId);

        modelBuilder.Entity<SourceFormatNode>()
            .HasOne(p => p.RootNode)
            .WithMany(p => p.NodesInTheTree)
            .HasForeignKey(k => k.RootNodeId)
            .IsRequired(false);

        modelBuilder.Entity<Document>().ToTable("document");
        modelBuilder.Entity<Document>().HasKey(k => k.Id);
        modelBuilder.Entity<Document>().Property(k => k.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Document>().Property(k => k.Id).HasColumnName("id");
        modelBuilder.Entity<Document>().Property(k => k.Name).HasColumnName("name");
        modelBuilder.Entity<Document>().HasIndex(k => k.Name).IsUnique();
        modelBuilder.Entity<Document>().Property(k => k.Description).HasColumnName("description");
        modelBuilder.Entity<Document>().Property(k => k.Uri).HasColumnName("uri");
#pragma warning restore CA1062
    }
}