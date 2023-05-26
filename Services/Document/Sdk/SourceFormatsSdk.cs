namespace EncyclopediaGalactica.SourceFormats.Sdk;

using Interfaces;

/// <inheritdoc />
public class SourceFormatsSdk : ISourceFormatsSdk
{
    public SourceFormatsSdk(
        ISourceFormatNodeSdk sourceFormatNodeSdk,
        IDocumentsSdk documentsSdk)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatNodeSdk);
        ArgumentNullException.ThrowIfNull(documentsSdk);

        SourceFormatNode = sourceFormatNodeSdk;
        DocumentsSdk = documentsSdk;
    }

    /// <inheritdoc />
    public ISourceFormatNodeSdk SourceFormatNode { get; }

    /// <inheritdoc />
    public IDocumentsSdk DocumentsSdk { get; }
}