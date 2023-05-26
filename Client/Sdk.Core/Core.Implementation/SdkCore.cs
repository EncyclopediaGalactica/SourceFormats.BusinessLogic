namespace EncyclopediaGalactica.Sdk.Core;

using Interfaces;
using Model.Interfaces;
using Newtonsoft.Json;

public class SdkCore : ISdkCore
{
    private readonly HttpClient _httpClient;

    public SdkCore(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<TResponseModel> SendAsync<TResponseModel, TResponseModelPayload>(
        HttpRequestMessage httpRequestMessage,
        CancellationToken cancellationToken = default)
        where TResponseModel : IHttpResponseModel<TResponseModelPayload>, new()
    {
        ArgumentNullException.ThrowIfNull(httpRequestMessage);

        HttpResponseMessage response = await _httpClient.SendAsync(
                httpRequestMessage,
                cancellationToken)
            .ConfigureAwait(false);

        TResponseModel res = await CreateResponse<TResponseModel, TResponseModelPayload>(
                response,
                cancellationToken)
            .ConfigureAwait(false);

        return res;
    }

    private async Task<TResponseModel> CreateResponse<TResponseModel, TResponseModelPayload>(
        HttpResponseMessage httpResponseMessage,
        CancellationToken cancellationToken = default)
        where TResponseModel : IHttpResponseModel<TResponseModelPayload>, new()
    {
        TResponseModel result = Activator.CreateInstance<TResponseModel>();
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            result.IsOperationSuccessful = false;

            string payload = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            result.Message = payload;
            result.HttpStatusCode = httpResponseMessage.StatusCode;

            return result;
        }

        TResponseModelPayload? deserializedPayload = await DeserializeResponse<TResponseModelPayload>(
                httpResponseMessage,
                cancellationToken)
            .ConfigureAwait(false);

        if (deserializedPayload is null
            && httpResponseMessage.RequestMessage?.Method != HttpMethod.Delete)
            throw new Exception("Response is null.");

        result.IsOperationSuccessful = true;
        result.Result = deserializedPayload;
        result.HttpStatusCode = httpResponseMessage.StatusCode;

        return result;
    }

    private async Task<T?> DeserializeResponse<T>(
        HttpResponseMessage response,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(response);

        string content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        T? result = JsonConvert.DeserializeObject<T>(content);
        return result;
    }
}