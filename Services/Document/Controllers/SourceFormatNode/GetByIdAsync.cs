namespace EncyclopediaGalactica.SourceFormats.Controllers.SourceFormatNode;

using System.Net.Mime;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public partial class SourceFormatNodeController
{
    [HttpGet]
    [Route("getbyid/{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SourceFormatNodeDto>> GetByIdAsync(
        long id)
    {
        return await _sourceFormatsService
            .SourceFormatNode
            .GetByIdAsync(id)
            .ConfigureAwait(false);
    }
}