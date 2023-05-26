namespace EncyclopediaGalactica.SourceFormats.Controllers.SourceFormatNode;

using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public partial class SourceFormatNodeController
{
    [HttpPut]
    [Route("update")]
    [ProducesResponseType(typeof(SourceFormatNodeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SourceFormatNodeDto>> Update(
        [FromBody] SourceFormatNodeDto? dto)
    {
        if (dto is null)
            _logger.LogWarning("{Dto} is null ", dto);

        try
        {
            var res = await _sourceFormatsService
                .SourceFormatNode
                .UpdateSourceFormatNodeAsync(dto)
                .ConfigureAwait(false);
            return res;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}