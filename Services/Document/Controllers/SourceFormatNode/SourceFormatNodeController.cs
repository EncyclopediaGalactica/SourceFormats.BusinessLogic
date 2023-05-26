namespace EncyclopediaGalactica.SourceFormats.Controllers.SourceFormatNode;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SourceFormatsService.Interfaces;

[ApiController]
[Route("api/sourceformats/[controller]")]
public partial class SourceFormatNodeController : ControllerBase
{
    private readonly ILogger<SourceFormatNodeController> _logger;
    private readonly ISourceFormatsService _sourceFormatsService;

    public SourceFormatNodeController(
        ISourceFormatsService sourceFormatsService,
        ILogger<SourceFormatNodeController> logger)
    {
        ArgumentNullException.ThrowIfNull(sourceFormatsService);
        ArgumentNullException.ThrowIfNull(logger);

        _sourceFormatsService = sourceFormatsService;
        _logger = logger;
    }
}