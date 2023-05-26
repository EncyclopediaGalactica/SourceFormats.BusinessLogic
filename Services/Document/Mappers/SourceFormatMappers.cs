namespace EncyclopediaGalactica.SourceFormats.Mappers;

using Interfaces;

public class SourceFormatMappers : ISourceFormatMappers
{
    public SourceFormatMappers(
        ISourceFormatNodeMappers sourceFormatNodeMappers,
        IDocumentMappers documentMappers)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatNodeMappers);
        ArgumentNullException.ThrowIfNull(documentMappers);

        SourceFormatNodeMappers = sourceFormatNodeMappers;
        DocumentMappers = documentMappers;
    }

    public IDocumentMappers DocumentMappers { get; }
    public ISourceFormatNodeMappers SourceFormatNodeMappers { get; }
}