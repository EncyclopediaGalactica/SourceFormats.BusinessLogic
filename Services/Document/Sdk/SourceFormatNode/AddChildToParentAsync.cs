namespace EncyclopediaGalactica.SourceFormats.Sdk.SourceFormatNode;

using Api;
using Dtos;
using Exceptions;
using Models;
using Models.SourceFormatNode;

public partial class SourceFormatNodeSdk
{
    /// <inheritdoc />
    public async Task<SourceFormatNodeAddChildToParentResponseModel> AddChildToParentAsync(
        SourceFormatNodeAddChildToParentRequestModel requestModel,
        CancellationToken cancellationToken = default)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(requestModel);

            String uri = SourceFormats.SourceFormatNode.Route + SourceFormats.SourceFormatNode.AddChildToParent;

            HttpRequestMessageBuilder<SourceFormatNodeAddChildToParentRequestModel> builder =
                new HttpRequestMessageBuilder<SourceFormatNodeAddChildToParentRequestModel>();
            HttpRequestMessage httpRequestMessage = builder
                .SetUri(uri)
                .SetContent(requestModel)
                .SetAcceptHeaders(requestModel.AcceptHeaders)
                .SetHttpMethod(HttpMethod.Put)
                .Build();

            SourceFormatNodeAddChildToParentResponseModel responseModel = await _sdkCore
                .SendAsync<SourceFormatNodeAddChildToParentResponseModel, SourceFormatNodeDto>(
                    httpRequestMessage,
                    cancellationToken)
                .ConfigureAwait(false);
            return responseModel;
        }
        catch (Exception e)
        {
            string msg =
                $"Error happened while executing {nameof(SourceFormatNodeSdk)}.{nameof(AddChildToParentAsync)}. " +
                "For further information see inner exception.";
            throw new SdkException(msg, e);
        }
    }
}