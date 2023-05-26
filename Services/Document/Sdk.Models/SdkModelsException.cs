namespace EncyclopediaGalactica.SourceFormats.Sdk.Models;

using System.Runtime.Serialization;

public class SdkModelsException : Exception
{
    public SdkModelsException()
    {
    }

    protected SdkModelsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public SdkModelsException(string? message) : base(message)
    {
    }

    public SdkModelsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}