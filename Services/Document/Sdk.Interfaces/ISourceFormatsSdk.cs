namespace EncyclopediaGalactica.SourceFormats.Sdk.Interfaces;

/// <summary>
///     The ISourceFormatsSdk interface.
///     <remarks>
///         It includes all domain specific Sdk interfaces.
///     </remarks>
/// </summary>
public interface ISourceFormatsSdk
{
    /// <summary>
    /// Gets the <see cref="ISourceFormatNodeSdk"/> Sdk.
    /// </summary>
    ISourceFormatNodeSdk SourceFormatNode { get; }

    /// <summary>
    /// Gets the <see cref="IDocumentsSdk"/> Sdk.
    /// </summary>
    IDocumentsSdk DocumentsSdk { get; }
}