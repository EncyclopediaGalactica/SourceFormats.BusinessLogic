namespace EncyclopediaGalactica.SourceFormats.Sdk.SourceFormatNode;

using Api;
using Dtos;
using Exceptions;
using Models;
using Models.SourceFormatNode;

public partial class SourceFormatNodeSdk
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeUpdateResponseModel> UpdateAsync(
        SourceFormatNodeUpdateRequestModel updateRequestModel,
        CancellationToken cancellationToken = default)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(updateRequestModel);
            ArgumentNullException.ThrowIfNull(updateRequestModel.Payload);

            const string url = SourceFormats.SourceFormatNode.Route + SourceFormats.SourceFormatNode.Update;

            HttpRequestMessage requestMessage = new HttpRequestMessageBuilder<SourceFormatNodeDto>()
                .SetUri(url)
                .SetHttpMethod(HttpMethod.Put)
                .SetContent(updateRequestModel.Payload)
                .SetAcceptHeaders(updateRequestModel.AcceptHeaders)
                .Build();

            SourceFormatNodeUpdateResponseModel response = await _sdkCore
                .SendAsync<SourceFormatNodeUpdateResponseModel, SourceFormatNodeDto>(requestMessage, cancellationToken)
                .ConfigureAwait(false);

            return response;
        }
        catch (Exception e)
        {
            string msg = $"Error happened while executing {nameof(SourceFormatNodeSdk)}.{nameof(UpdateAsync)}. " +
                         "For further information see inner exception.";
            throw new SdkException(msg, e);
        }
    }
}