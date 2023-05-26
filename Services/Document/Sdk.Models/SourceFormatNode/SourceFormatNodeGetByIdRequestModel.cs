namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.SourceFormatNode;

using System.Net.Http.Headers;
using Dtos;
using EncyclopediaGalactica.Sdk.Core.Model.Interfaces;

/// <summary>
///     <see cref="SourceFormatNodeGetByIdRequestModel" />
///     This is the request object for the provided SDK of the SourceFormats Service
///     to get the designated <see cref="SourceFormatNode" /> object properties
///     carried by a <see cref="SourceFormatNodeDto" /> data transfer object.
/// </summary>
public class SourceFormatNodeGetByIdRequestModel : IRequestModel<SourceFormatNodeDto>
{
    /// <summary>
    ///     Gets or sets the Payload
    ///     This <see cref="SourceFormatNodeDto" /> object Id fields marks the
    ///     object we are looking up in the database
    /// </summary>
    public SourceFormatNodeDto? Payload { get; private init; }

    /// <summary>
    ///     Gets or sets AcceptHeaders
    /// </summary>
    public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; private init; }

    public class Builder
    {
        private List<MediaTypeWithQualityHeaderValue> _acceptHeaders = new List<MediaTypeWithQualityHeaderValue>();
        private long _id;

        /// <summary>
        ///     Sets the Id value.
        /// </summary>
        /// <param name="id">The unique identifier of th object</param>
        /// <returns>
        ///     Returns instance of <see cref="SourceFormatNodeGetByIdRequestModel.Builder" />
        /// </returns>
        public Builder SetId(long id)
        {
            _id = id;
            return this;
        }

        /// <summary>
        ///     Adds header value to AcceptHeaders
        /// </summary>
        /// <param name="headerValue">A header value</param>
        /// <returns>
        ///     Returns instance of <see cref="SourceFormatNodeGetByIdRequestModel.Builder" />
        /// </returns>
        public Builder AddAcceptHeader(MediaTypeWithQualityHeaderValue headerValue)
        {
            _acceptHeaders.Add(headerValue);
            return this;
        }

        /// <summary>
        ///     Creates a <see cref="SourceFormatNodeGetByIdRequestModel" />
        /// </summary>
        /// <returns></returns>
        public SourceFormatNodeGetByIdRequestModel Build()
        {
            if (_id == 0)
            {
                throw new SdkModelsException($"Id cannot be zero");
            }

            SourceFormatNodeGetByIdRequestModel model = new SourceFormatNodeGetByIdRequestModel
            {
                Payload = new SourceFormatNodeDto { Id = _id },
                AcceptHeaders = _acceptHeaders
            };
            return model;
        }
    }
}