namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Interfaces;

using Document;
using SourceFormatNode;

/// <summary>
///     A facade interface for all SourceFormat related services.
/// </summary>
public interface ISourceFormatsService
{
    /// <summary>
    ///     Gets the SourceFormatNode service.
    /// </summary>
    ISourceFormatNodeService SourceFormatNode { get; }

    /// <summary>
    ///     Gets the Document service.
    /// </summary>
    IDocumentService DocumentService { get; }
}