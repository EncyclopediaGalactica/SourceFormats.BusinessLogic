namespace EncyclopediaGalactica.SourceFormats.Mappers.Interfaces;

using Dtos;
using Entities;

/// <summary>
///     The IDocumentMapper interface
///     <remarks>
///         It provides methods to map <see cref="Document" /> to <see cref="DocumentDto" /> and back
///     </remarks>
/// </summary>
public interface IDocumentMappers
{
    /// <summary>
    ///     Maps <see cref="DocumentDto" /> to <see cref="Document" />
    /// </summary>
    /// <param name="dto">the input dto</param>
    /// <returns><see cref="Document" /> object</returns>
    Document MapDocumentDtoToDocument(DocumentDto dto);

    /// <summary>
    ///     Maps <see cref="Document" /> to <see cref="DocumentDto" />
    /// </summary>
    /// <param name="document">the input document</param>
    /// <returns>
    ///     <see cref="DocumentDto" />
    /// </returns>
    DocumentDto MapDocumentToDocumentDto(Document document);
}