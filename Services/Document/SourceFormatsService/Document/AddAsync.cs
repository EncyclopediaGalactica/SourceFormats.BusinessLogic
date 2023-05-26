namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Document;

using Dtos;
using Entities;

public partial class DocumentService
{
    /// <inheritdoc />
    public async Task<DocumentDto> AddAsync(DocumentDto dto, CancellationToken cancellationToken = default)
    {
        _guardsService.NotNull(dto);

        Document document = _mappers.DocumentMappers.MapDocumentDtoToDocument(dto);
        Document result = await _repository.AddAsync(document, cancellationToken).ConfigureAwait(false);
        DocumentDto resultDto = _mappers.DocumentMappers.MapDocumentToDocumentDto(result);
        return resultDto;
    }
}