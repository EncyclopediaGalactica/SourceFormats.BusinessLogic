namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.SourceFormatNode;

using System.Net;
using Dtos;
using EncyclopediaGalactica.Sdk.Core.Model.Interfaces;

public class SourceFormatNodeAddChildToParentResponseModel : IHttpResponseModel<SourceFormatNodeDto>
{
    public SourceFormatNodeDto? Result { get; set; }
    public bool IsOperationSuccessful { get; set; }
    public string? Message { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }

    public class Builder
    {
        private HttpStatusCode? _httpStatusCode;
        private bool _isOperationSuccessful;
        private string? _message;
        private SourceFormatNodeDto? _result;

        public Builder SetResult(SourceFormatNodeDto dto)
        {
            _result = dto;
            return this;
        }

        public Builder SetOperationSuccessful()
        {
            _isOperationSuccessful = true;
            return this;
        }

        public Builder SetOperationFailed()
        {
            _isOperationSuccessful = false;
            return this;
        }

        public Builder SetHttpStatusCode(HttpStatusCode statusCode)
        {
            _httpStatusCode = statusCode;
            return this;
        }

        public Builder SetMessage(string message)
        {
            _message = message;
            return this;
        }

        public SourceFormatNodeAddChildToParentResponseModel Build()
        {
            if (_httpStatusCode is null)
                throw new ArgumentNullException("Http status code must be set.");

            if (_message is null)
                throw new ArgumentNullException("Message is not set");

            SourceFormatNodeAddChildToParentResponseModel responseModel = new()
            {
                Result = _result,
                IsOperationSuccessful = _isOperationSuccessful,
                Message = _message,
                HttpStatusCode = (HttpStatusCode)_httpStatusCode
            };

            return responseModel;
        }
    }
}