namespace EncyclopediaGalactica.SourceFormats.Sdk.SourceFormatNode;

using Api;
using Dtos;
using Exceptions;
using Models;
using Models.SourceFormatNode;

public partial class SourceFormatNodeSdk
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeDeleteResponseModel> DeleteAsync(
        SourceFormatNodeDeleteRequestModel deleteRequestModel,
        CancellationToken cancellationToken = default)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(deleteRequestModel);
            ArgumentNullException.ThrowIfNull(deleteRequestModel.Payload);

            const string url = SourceFormats.SourceFormatNode.Route + SourceFormats.SourceFormatNode.Delete;

            HttpRequestMessageBuilder<SourceFormatNodeDto?> httpRequestMessageBuilder = new();
            HttpRequestMessage httpRequestMessage = httpRequestMessageBuilder
                .SetContent(deleteRequestModel.Payload)
                .SetUri(url)
                .SetAcceptHeaders(deleteRequestModel.AcceptHeaders)
                .SetHttpMethod(HttpMethod.Delete)
                .Build();

            SourceFormatNodeDeleteResponseModel responseModel = await _sdkCore
                .SendAsync<SourceFormatNodeDeleteResponseModel, SourceFormatNodeDto>(
                    httpRequestMessage,
                    cancellationToken)
                .ConfigureAwait(false);
            return responseModel;
        }
        catch (Exception e)
        {
            string msg = $"Error happened while executing {nameof(SourceFormatNodeSdk)}.{nameof(DeleteAsync)}. " +
                         "For further information see inner exception.";
            throw new SdkException(msg, e);
        }
    }
}