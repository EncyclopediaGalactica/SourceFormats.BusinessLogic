namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Exceptions;

using System.Runtime.Serialization;

public class SourceFormatNodeServiceException : Exception
{
    public SourceFormatNodeServiceException()
    {
    }

    protected SourceFormatNodeServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public SourceFormatNodeServiceException(string? message) : base(message)
    {
    }

    public SourceFormatNodeServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}