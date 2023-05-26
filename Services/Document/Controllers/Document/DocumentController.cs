namespace EncyclopediaGalactica.SourceFormats.Controllers.Document;

using System.Net.Mime;
using Dtos;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SourceFormatNode;
using SourceFormatsService.Interfaces;

[ApiController]
[Route("api/sourceformats/[controller]")]
public partial class DocumentController : ControllerBase
{
    private readonly ILogger<DocumentController> _logger;
    private readonly ISourceFormatsService _sourceFormatsService;

    public DocumentController(
        ISourceFormatsService sourceFormatsService,
        ILogger<DocumentController> logger)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatsService);
        ArgumentNullException.ThrowIfNull(logger);

        _sourceFormatsService = sourceFormatsService;
        _logger = logger;
    }
}