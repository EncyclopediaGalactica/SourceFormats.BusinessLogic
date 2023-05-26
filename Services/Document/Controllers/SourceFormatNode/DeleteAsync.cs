namespace EncyclopediaGalactica.SourceFormats.Controllers.SourceFormatNode;

using System.Net.Mime;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SourceFormatsService.Interfaces.SourceFormatNode;

public partial class SourceFormatNodeController

{
    [HttpDelete]
    [Route("delete")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(SourceFormatNodeSingleResultResponseModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task DeleteAsync(
        [FromBody] SourceFormatNodeDto? dto)
    {
        if (dto is null)
            _logger.LogInformation("{RequestModel} is null", nameof(dto));

        await _sourceFormatsService
            .SourceFormatNode
            .DeleteAsync(dto!)
            .ConfigureAwait(false);
    }
}