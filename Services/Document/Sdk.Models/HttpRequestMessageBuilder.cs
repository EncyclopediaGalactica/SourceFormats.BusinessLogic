namespace EncyclopediaGalactica.SourceFormats.Sdk.Models;

using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using Newtonsoft.Json;

public class HttpRequestMessageBuilder<T>
{
    private List<MediaTypeWithQualityHeaderValue> _acceptHeaders;
    private Uri _baseAddress;
    private T? _content;
    private string _contentType;
    private HttpMethod _httpMethod;
    private string _uri;

    public HttpRequestMessage Build()
    {
        _acceptHeaders = new List<MediaTypeWithQualityHeaderValue>();
        MediaTypeWithQualityHeaderValue json = new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json);
        _acceptHeaders.Add(json);

        HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Content = CreateContent();
        CreateHeaders(httpRequestMessage);

        UriBuilder uriBuilder = new UriBuilder
        {
            Path = _uri
        };
        Uri requestUri = uriBuilder.Uri;

        httpRequestMessage.RequestUri = requestUri;
        httpRequestMessage.Method = _httpMethod;

        return httpRequestMessage;
    }

    private void CreateHeaders(HttpRequestMessage httpRequestMessage)
    {
        if (httpRequestMessage is null)
            throw new ArgumentNullException(nameof(httpRequestMessage));

        if (_acceptHeaders.Any())
        {
            foreach (MediaTypeWithQualityHeaderValue mediaTypeWithQualityHeaderValue in _acceptHeaders)
            {
                httpRequestMessage.Headers.Accept.Add(mediaTypeWithQualityHeaderValue);
            }
        }
    }

    private HttpContent? CreateContent()
    {
        if (_content is not null)
        {
            string contentType;
            if (_contentType is null)
            {
                contentType = MediaTypeNames.Application.Json;
            }
            else
            {
                contentType = _contentType;
            }

            string jsonContent = JsonConvert.SerializeObject(_content);
            StringContent stringContent = new StringContent(jsonContent, Encoding.UTF8, contentType);
            return stringContent;
        }

        return null;
    }

    public HttpRequestMessageBuilder<T> SetContentType(string contentType)
    {
        _contentType = contentType;
        return this;
    }

    public HttpRequestMessageBuilder<T> SetContent(T? requestModelPayload)
    {
        _content = requestModelPayload;
        return this;
    }

    public HttpRequestMessageBuilder<T> SetAcceptHeaders(List<MediaTypeWithQualityHeaderValue> acceptHeaders)
    {
        _acceptHeaders = acceptHeaders;
        return this;
    }

    public HttpRequestMessageBuilder<T> SetUri(string url)
    {
        _uri = url;
        return this;
    }

    public HttpRequestMessageBuilder<T> SetHttpMethod(HttpMethod httpMethod)
    {
        _httpMethod = httpMethod;
        return this;
    }

    private HttpRequestMessageBuilder<T> SetBaseAddress(Uri baseAddressUri)
    {
        _baseAddress = baseAddressUri;
        return this;
    }
}