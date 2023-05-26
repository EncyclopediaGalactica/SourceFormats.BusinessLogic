namespace EncyclopediaGalactica.Sdk.Core.Model.Interfaces;

using System.Net.Http.Headers;

public interface IRequestModel<TPayloadType>
{
    public TPayloadType? Payload { get; }
    public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; }
}