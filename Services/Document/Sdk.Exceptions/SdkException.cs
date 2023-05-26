namespace EncyclopediaGalactica.SourceFormats.Sdk.Exceptions;

using System.Runtime.Serialization;

public class SdkException : Exception
{
    public SdkException()
    {
    }

    protected SdkException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public SdkException(string? message) : base(message)
    {
    }

    public SdkException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}