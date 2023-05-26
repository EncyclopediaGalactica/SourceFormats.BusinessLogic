namespace EncyclopediaGalactica.SourceFormats.Sdk.SourceFormatNode;

using Api;
using Dtos;
using Exceptions;
using Models;
using Models.SourceFormatNode;

public partial class SourceFormatNodeSdk
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeGetAllResponseModel> GetAllAsync(
        SourceFormatNodeGetAllRequestModel requestModel,
        CancellationToken cancellationToken = default)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(requestModel);

            string uri = SourceFormats.SourceFormatNode.Route + SourceFormats.SourceFormatNode.GetAll;

            HttpRequestMessageBuilder<List<SourceFormatNodeDto>> httpRequestMessageBuilder =
                new HttpRequestMessageBuilder<List<SourceFormatNodeDto>>();
            HttpRequestMessage httpRequestMessage = httpRequestMessageBuilder
                .SetUri(uri)
                .SetHttpMethod(HttpMethod.Get)
                .SetAcceptHeaders(requestModel.AcceptHeaders)
                .Build();

            SourceFormatNodeGetAllResponseModel result = await _sdkCore
                .SendAsync<SourceFormatNodeGetAllResponseModel, List<SourceFormatNodeDto>>(
                    httpRequestMessage,
                    cancellationToken)
                .ConfigureAwait(false);
            return result;
        }
        catch (Exception e)
        {
            string msg = $"Error happened while executing {nameof(SourceFormatNodeSdk)}.{nameof(GetAllAsync)}. " +
                         "For further information see inner exception.";
            throw new SdkException(msg, e);
        }
    }
}