namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.SourceFormatNode;

using System.Net.Http.Headers;
using Dtos;
using EncyclopediaGalactica.Sdk.Core.Model.Interfaces;
using FluentValidation;
using ValidatorService;

public class SourceFormatNodeUpdateRequestModel : IRequestModel<SourceFormatNodeDto>
{
    public SourceFormatNodeDto? Payload { get; private init; }

    public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; private init; } = new();

    public class Builder
    {
        private readonly List<MediaTypeWithQualityHeaderValue> _acceptHeaders = new();
        private long _id;
        private string _name;

        public Builder SetId(long id)
        {
            _id = id;
            return this;
        }

        public Builder SetName(string name)
        {
            _name = name;
            return this;
        }

        public Builder AddAcceptHeader(MediaTypeWithQualityHeaderValue header)
        {
            _acceptHeaders.Add(header);
            return this;
        }

        public SourceFormatNodeUpdateRequestModel Build()
        {
            SourceFormatNodeDto dto = new()
            {
                Id = _id,
                Name = _name
            };

            SourceFormatNodeDtoValidator validator = new();
            validator.Validate(dto, options =>
            {
                options.IncludeRuleSets(SourceFormatNodeDtoValidator.Update);
                options.ThrowOnFailures();
            });

            SourceFormatNodeUpdateRequestModel requestModel = new()
            {
                Payload = dto,
                AcceptHeaders = _acceptHeaders
            };

            return requestModel;
        }
    }
}