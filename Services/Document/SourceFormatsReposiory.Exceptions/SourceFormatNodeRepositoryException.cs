namespace EncyclopediaGalactica.SourceFormats.SourceFormatsRepository.Exceptions;

using System.Runtime.Serialization;

public class SourceFormatNodeRepositoryException : Exception
{
    public SourceFormatNodeRepositoryException()
    {
    }

    protected SourceFormatNodeRepositoryException(SerializationInfo info, StreamingContext context) : base(info,
        context)
    {
    }

    public SourceFormatNodeRepositoryException(string? message) : base(message)
    {
    }

    public SourceFormatNodeRepositoryException(string? message, Exception? innerException) : base(message,
        innerException)
    {
    }
}