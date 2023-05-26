namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.SourceFormatNode;

using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Dtos;
using EncyclopediaGalactica.Sdk.Core.Model.Interfaces;

public class SourceFormatNodeDeleteRequestModel : IRequestModel<SourceFormatNodeDto>
{
    /// <summary>
    ///     Creates a new instance
    /// </summary>
    public SourceFormatNodeDeleteRequestModel()
    {
    }

    /// <summary>
    ///     The payload object which contains details of the SourceFormatNode object
    ///     we wish to create.
    /// </summary>
    [JsonPropertyName("payload")]
    public SourceFormatNodeDto? Payload { get; init; }

    public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; init; }
        = new List<MediaTypeWithQualityHeaderValue>();

    public class Builder
    {
        public long Id { get; set; }

        public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; set; } =
            new List<MediaTypeWithQualityHeaderValue>();

        /// <summary>
        ///     Sets the Id value.
        /// </summary>
        /// <param name="id">Unique identifier of the entity to be deleted</param>
        /// <returns>
        ///     Returns instance of <see cref="SourceFormatNodeDeleteRequestModel.Builder" />
        ///     instance
        /// </returns>
        public Builder SetId(long id)
        {
            Id = id;
            return this;
        }

        /// <summary>
        ///     Adds the provided header value to the list of Accepted Headers.
        ///     The list of headers will be added to the Http request.
        /// </summary>
        /// <param name="mediaType">The header</param>
        /// <returns>
        ///     Returns instance of <see cref="SourceFormatNodeDeleteRequestModel.Builder" />
        ///     instance
        /// </returns>
        public Builder AddAcceptHeader(string mediaType)
        {
            MediaTypeWithQualityHeaderValue value = new MediaTypeWithQualityHeaderValue(mediaType);
            AcceptHeaders.Add(value);
            return this;
        }

        /// <summary>
        ///     Creates an instance of <see cref="SourceFormatNodeDeleteRequestModel" />
        ///     where its properties are set up to the defined values provided by
        ///     using the set methods of this builder.
        ///     The provided values are validated.
        /// </summary>
        /// <returns>
        ///     Returns an instance of <see cref="SourceFormatNodeDeleteRequestModel" />
        /// </returns>
        public SourceFormatNodeDeleteRequestModel Build()
        {
            try
            {
                if (Id is 0)
                {
                    throw new SdkModelsException(
                        $"{Id} cannot be null or zero.");
                }

                SourceFormatNodeDto dto = new SourceFormatNodeDto
                {
                    Id = Id
                };

                SourceFormatNodeDeleteRequestModel model = new SourceFormatNodeDeleteRequestModel
                {
                    Payload = dto,
                    AcceptHeaders = AcceptHeaders
                };
                return model;
            }
            catch (Exception e)
            {
                throw new SdkModelsException(
                    $"Error happened while building {nameof(SourceFormatNodeDeleteRequestModel)}." +
                    $"For further details see inner exception.");
            }
        }
    }
}