namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Interfaces;

using Entities;

public interface IDocumentsRepository
{
    Task<Document> AddAsync(Document document, CancellationToken cancellationToken = default);
    Task<Document> GetByIdAsync(long id, CancellationToken cancellationToken = default);

    Task<List<Document>> GetAllAsync(CancellationToken cancellationToken = default);
}