namespace EncyclopediaGalactica.SourceFormats.Sdk.Models.SourceFormatNode;

using System.Net.Http.Headers;
using Dtos;
using EncyclopediaGalactica.Sdk.Core.Model.Interfaces;

/// <summary>
///     <see cref="SourceFormatNodeAddChildToParentRequestModel" /> is part of the provided SDK,
///     and makes possible to execute the operation where a <see cref="SourceFormatNode" /> is added
///     to another <see cref="SourceFormatNode" /> as child. The data is sent to the endpoint using
///     <see cref="SourceFormatNodeDto" /> types.
/// </summary>
public class SourceFormatNodeAddChildToParentRequestModel : IRequestModel<SourceFormatNodeDto>
{
    /// <summary>
    ///     Gets Payload
    /// </summary>
    public SourceFormatNodeDto? Payload { get; private init; }

    /// <summary>
    ///     Gets AcceptHeaders
    /// </summary>
    public List<MediaTypeWithQualityHeaderValue> AcceptHeaders { get; private init; }

    public class Builder
    {
        private List<MediaTypeWithQualityHeaderValue> _acceptHeaders = new List<MediaTypeWithQualityHeaderValue>();
        private long _childrenNodeId;
        private long _parentNodeId;
        private SourceFormatNodeDto _payload;

        public Builder SetChildrenNodeId(long id)
        {
            _childrenNodeId = id;
            return this;
        }

        public Builder SetParentNodeId(long id)
        {
            _parentNodeId = id;
            return this;
        }

        public Builder AddAcceptHeader(MediaTypeWithQualityHeaderValue acceptHeader)
        {
            _acceptHeaders.Add(acceptHeader);
            return this;
        }

        public SourceFormatNodeAddChildToParentRequestModel Build()
        {
            if (_childrenNodeId == 0 || _parentNodeId == 0)
            {
                throw new SdkModelsException("Id cannot be zero.");
            }

            SourceFormatNodeDto payload = new SourceFormatNodeDto
            {
                Id = _childrenNodeId,
                ParentNodeId = _parentNodeId,
            };

            SourceFormatNodeAddChildToParentRequestModel requestModel = new SourceFormatNodeAddChildToParentRequestModel
            {
                Payload = payload,
                AcceptHeaders = _acceptHeaders
            };
            return requestModel;
        }
    }
}