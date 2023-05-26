namespace EncyclopediaGalactica.SourceFormats.Controllers.SourceFormatNode;

using System.Net.Mime;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels;

public partial class SourceFormatNodeController
{
    [HttpPut]
    [Route("addchildtoparent")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(SourceFormatNodeSingleResultViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SourceFormatNodeDto>> AddChildToParentAsync(
        [FromBody] SourceFormatNodeDto? dto)
    {
        if (dto is null)
            _logger.LogInformation("{RequestModel} is null", nameof(dto));

        return await _sourceFormatsService
            .SourceFormatNode
            .AddChildToParentAsync(
                new SourceFormatNodeDto { Id = dto!.Id },
                new SourceFormatNodeDto { Id = (long)dto.ParentNodeId! })
            .ConfigureAwait(false);
    }
}