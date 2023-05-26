namespace EncyclopediaGalactica.SourceFormats.Mappers.Interfaces;

public interface ISourceFormatMappers
{
    ISourceFormatNodeMappers SourceFormatNodeMappers { get; }
    IDocumentMappers DocumentMappers { get; }
}