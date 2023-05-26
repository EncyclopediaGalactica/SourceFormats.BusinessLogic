namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Document;

using Dtos;
using Entities;

public partial class DocumentService
{
    /// <inheritdoc />
    public async Task<DocumentDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        _guardsService.IsNotEqual(id, 0);
        Document result = await _repository.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        DocumentDto dto = _mappers.DocumentMappers.MapDocumentToDocumentDto(result);
        return dto;
    }
}