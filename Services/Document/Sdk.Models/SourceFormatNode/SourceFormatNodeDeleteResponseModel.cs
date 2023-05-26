namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.SourceFormatNode;

using System.Net;
using Dtos;
using EncyclopediaGalactica.Sdk.Core.Model.Interfaces;

/// <summary>
///     <see cref="SourceFormatNodeDeleteResponseModel" /> which is used for carrying
///     execution result related information to the client side.
///     It is used only in the provided SDK.
/// </summary>
public class SourceFormatNodeDeleteResponseModel : IHttpResponseModel<SourceFormatNodeDto>
{
    /// <summary>
    ///     Sets or gets the operation result.
    /// </summary>
    public SourceFormatNodeDto? Result { get; set; }

    /// <summary>
    ///     Sets or gets whether the operation was successful
    /// </summary>
    public bool IsOperationSuccessful { get; set; }

    /// <summary>
    ///     Sets or gets the message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    ///     Sets or gets the http status code
    /// </summary>
    public HttpStatusCode HttpStatusCode { get; set; }

    public class Builder
    {
        private HttpStatusCode? _httpStatusCode;
        private bool _isOperationSuccessful;
        private string? _message;
        private SourceFormatNodeDto? _result;

        /// <summary>
        ///     Sets the result value.
        /// </summary>
        /// <param name="dto">The result <see cref="SourceFormatNodeDto" /></param>
        /// <returns>
        ///     Returns the instance of <see cref="SourceFormatNodeDto" />
        /// </returns>
        public Builder SetResult(SourceFormatNodeDto dto)
        {
            _result = dto;
            return this;
        }

        /// <summary>
        ///     Sets the operation execution to success
        /// </summary>
        /// <returns>
        ///     Returns the instance of <see cref="SourceFormatNodeDto" />
        /// </returns>
        public Builder SetOperationSuccessful()
        {
            _isOperationSuccessful = true;
            return this;
        }

        /// <summary>
        ///     Sets the operation execution to failure
        /// </summary>
        /// <returns>
        ///     Returns the instance of <see cref="SourceFormatNodeDto" />
        /// </returns>
        public Builder SetOperationFailed()
        {
            _isOperationSuccessful = false;
            return this;
        }

        /// <summary>
        ///     Sets the http status code
        /// </summary>
        /// <param name="statusCode">The HTTP status code</param>
        /// <returns>
        ///     Returns the instance of <see cref="SourceFormatNodeDto" />
        /// </returns>
        public Builder SetHttpStatusCode(HttpStatusCode statusCode)
        {
            _httpStatusCode = statusCode;
            return this;
        }

        /// <summary>
        ///     Sets the Message
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>
        ///     Returns the instance of <see cref="SourceFormatNodeDto" />
        /// </returns>
        public Builder SetMessage(string message)
        {
            _message = message;
            return this;
        }

        /// <summary>
        ///     Builds a <see cref="SourceFormatNodeDeleteResponseModel" /> using the data provided
        ///     by the builder setter methods.
        /// </summary>
        /// <returns>
        ///     Returns the instance of <see cref="SourceFormatNodeDeleteResponseModel" /> where
        ///     the properties are populated.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     When a mandatory value is not provided.
        /// </exception>
        public SourceFormatNodeDeleteResponseModel Build()
        {
            ArgumentNullException.ThrowIfNull(_httpStatusCode);
            ArgumentNullException.ThrowIfNull(_message);

            SourceFormatNodeDeleteResponseModel responseModel = new SourceFormatNodeDeleteResponseModel
            {
                Message = _message,
                Result = _result,
                IsOperationSuccessful = _isOperationSuccessful,
                HttpStatusCode = (System.Net.HttpStatusCode)_httpStatusCode
            };
            return responseModel;
        }
    }
}