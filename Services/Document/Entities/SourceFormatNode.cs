namespace EncyclopediaGalactica.SourceFormats.Entities;

using System.Collections.ObjectModel;

/// <summary>
///     SourceFormatNode entity which is the atomic building block of a data structure.
///     This data structure is a tree where the nodes contains additional information about the following:
///     <list type="bullet">
///         <item>the structure itself meaning child entities</item>
///         <item>type of the node meaning it can be UI form</item>
///         <item>processing details meaning for example patterns</item>
///         <item>validation meaning validation rules for UI form</item>
///         <item>data related information</item>
///     </list>
///     The spine of this whole structure possibilities is the <see cref="SourceFormatNode" /> providing
///     the structure which makes possible to hook up additional information to the nodes.
/// </summary>
public class SourceFormatNode
{
    public SourceFormatNode()
    {
    }

    public SourceFormatNode(string? name)
    {
        Name = name;
    }

    public long Id { get; set; }
    public string? Name { get; set; }
    public int IsRootNode { get; set; }
    public long? ParentNodeId { get; set; }

    /// <summary>
    ///     Gets or sets the root node id.
    ///     It marks that to which root node's scope the node belongs to.
    /// </summary>
    public long? RootNodeId { get; set; }

    /// <summary>
    ///     Gets or sets the root node.
    ///     This is the root node where the tree starts and defines a scope. We mark the root node here
    ///     in order to narrow down the load on the database.
    /// </summary>
    public SourceFormatNode? RootNode { get; set; }

    /// <summary>
    ///     Gets or sets the list of nodes in the tree.
    ///     It contains all the nodes belong to the root node.
    /// </summary>
    public List<SourceFormatNode> NodesInTheTree { get; } = new List<SourceFormatNode>();

    public Collection<SourceFormatNode> ChildrenSourceFormatNodes { get; } = new Collection<SourceFormatNode>();
    public SourceFormatNode? ParentSourceFormatNode { get; set; }
}