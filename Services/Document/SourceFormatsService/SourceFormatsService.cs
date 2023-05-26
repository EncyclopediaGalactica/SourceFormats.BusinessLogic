namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService;

using Interfaces;
using Interfaces.Document;
using Interfaces.SourceFormatNode;

public class SourceFormatsService : ISourceFormatsService
{
    public SourceFormatsService(
        ISourceFormatNodeService sourceFormatNodeService,
        IDocumentService documentService)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatNodeService);
        ArgumentNullException.ThrowIfNull(documentService);

        SourceFormatNode = sourceFormatNodeService;
        DocumentService = documentService;
    }

    public ISourceFormatNodeService SourceFormatNode { get; }
    public IDocumentService DocumentService { get; }
}