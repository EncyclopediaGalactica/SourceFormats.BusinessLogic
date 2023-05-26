namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository;

using Interfaces;

public class SourceFormatsRepository : ISourceFormatsRepository
{
    public SourceFormatsRepository(
        ISourceFormatNodeRepository sourceFormatNodeRepository,
        IDocumentsRepository documents)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatNodeRepository);
        ArgumentNullException.ThrowIfNull(documents);

        SourceFormatNodes = sourceFormatNodeRepository;
        Documents = documents;
    }

    public ISourceFormatNodeRepository SourceFormatNodes { get; }
    public IDocumentsRepository Documents { get; }
}