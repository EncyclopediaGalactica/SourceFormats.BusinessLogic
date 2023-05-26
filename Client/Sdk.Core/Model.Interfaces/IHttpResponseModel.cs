namespace EncyclopediaGalactica.Sdk.Core.Model.Interfaces;

using System.Net;

public interface IHttpResponseModel<TResponsePayloadType>
{
    public TResponsePayloadType? Result { get; set; }
    public bool IsOperationSuccessful { get; set; }
    public string Message { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
}