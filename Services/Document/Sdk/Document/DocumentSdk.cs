namespace EncyclopediaGalactica.SourceFormats.Sdk.Document;

using EncyclopediaGalactica.Sdk.Core.Interfaces;
using Interfaces;
using Models.Document;

/// <inheritdoc />
public partial class DocumentSdk : IDocumentsSdk
{
    private readonly ISdkCore _sdkCore;

    public DocumentSdk(ISdkCore sdkCore)
    {
        ArgumentNullException.ThrowIfNull(sdkCore);
        _sdkCore = sdkCore;
    }
}