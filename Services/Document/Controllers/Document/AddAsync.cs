namespace EncyclopediaGalactica.SourceFormats.Controllers.Document;

using System.Net.Mime;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sdk.Models.Document;
using ViewModels;

public partial class DocumentController
{
    [HttpPost]
    [Route("add")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(DocumentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DocumentDto>> AddAsync(DocumentDto dto)
    {
        return await _sourceFormatsService.DocumentService.AddAsync(dto).ConfigureAwait(false);
    }
}