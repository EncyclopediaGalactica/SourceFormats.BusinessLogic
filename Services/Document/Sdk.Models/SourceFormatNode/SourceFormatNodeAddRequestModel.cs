namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.SourceFormatNode;

using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Dtos;
using EncyclopediaGalactica.Sdk.Core.Model.Interfaces;
using FluentValidation;
using ValidatorService;

/// <summary>
///     This model is used in creating new SourceFormatNode entity in the system.
///     It provides a Builder to collect all necessary data to do so. However, the builder does not represent
///     validation for the collected data.
/// </summary>
public class SourceFormatNodeAddRequestModel : IRequestModel<SourceFormatNodeDto>
{
    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public SourceFormatNodeAddRequestModel()
    {
    }

    /// <summary>
    ///     The payload object which contains details of the SourceFormatNode object
    ///     we wish to create.
    /// </summary>
    [JsonPropertyName("payload")]
    public SourceFormatNodeDto? Payload { get; private init; }

    public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; private init; } =
        new List<MediaTypeWithQualityHeaderValue>();

    public class Builder
    {
        private string? Name { get; set; }

        private List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; set; } =
            new List<MediaTypeWithQualityHeaderValue>();

        public Builder SetName(string name)
        {
            Name = name;
            return this;
        }

        public Builder AddAcceptHeader(string mediaType)
        {
            MediaTypeWithQualityHeaderValue value = new MediaTypeWithQualityHeaderValue(mediaType);
            AcceptHeaders.Add(value);
            return this;
        }

        public SourceFormatNodeAddRequestModel Build()
        {
            try
            {
                SourceFormatNodeDto dto = new SourceFormatNodeDto
                {
                    Name = Name
                };

                SourceFormatNodeDtoValidator validator = new SourceFormatNodeDtoValidator();
                validator.Validate(dto, options =>
                {
                    options.ThrowOnFailures();
                    options.IncludeRuleSets(SourceFormatNodeDtoValidator.Add);
                });

                SourceFormatNodeAddRequestModel requestModel = new SourceFormatNodeAddRequestModel
                {
                    Payload = dto,
                    AcceptHeaders = AcceptHeaders
                };
                return requestModel;
            }
            catch (Exception e)
            {
                const string msg = $"Error happened while building {nameof(SourceFormatNodeAddRequestModel)}.";
                throw new SdkModelsException(msg, e);
            }
        }
    }
}