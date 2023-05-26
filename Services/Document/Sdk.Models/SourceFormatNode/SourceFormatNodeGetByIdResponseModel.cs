namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.SourceFormatNode;

using System.Net;
using Dtos;
using EncyclopediaGalactica.Sdk.Core.Model.Interfaces;

public class SourceFormatNodeGetByIdResponseModel : IHttpResponseModel<SourceFormatNodeDto>
{
    public SourceFormatNodeDto? Result { get; set; }
    public bool IsOperationSuccessful { get; set; }
    public string Message { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
}