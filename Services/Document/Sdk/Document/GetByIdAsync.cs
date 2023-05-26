namespace EncyclopediaGalactica.SourceFormats.Sdk.Document;

using Api;
using Dtos;
using Models;
using Models.Document;

public partial class DocumentSdk
{
    /// <inheritdoc />
    public async Task<DocumentGetByIdResponseModel> GetByIdAsync(
        DocumentGetByIdRequestModel requestModel,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(requestModel);
        ArgumentNullException.ThrowIfNull(requestModel.Payload);

        string uri = SourceFormats.Document.Route
                     + SourceFormats.Document.GetById
                     + $"/{requestModel.Payload.Id}";

        HttpRequestMessageBuilder<DocumentDto> builder = new HttpRequestMessageBuilder<DocumentDto>();
        HttpRequestMessage httpRequestMessage = builder
            .SetContent(requestModel.Payload)
            .SetAcceptHeaders(requestModel.AcceptHeaders)
            .SetHttpMethod(HttpMethod.Get)
            .SetUri(uri)
            .Build();

        DocumentGetByIdResponseModel resultModel = await _sdkCore.SendAsync<DocumentGetByIdResponseModel, DocumentDto>(
                httpRequestMessage,
                cancellationToken)
            .ConfigureAwait(false);

        return resultModel;
    }
}