namespace EncyclopediaGalactica.SourceFormats.Controllers.ViewModels;

using Dtos;

public class SourceFormatNodeSingleResultViewModel
{
    public bool IsOperationSuccessful { get; set; }

    public SourceFormatNodeDto? Result { get; set; }

    public string? Message { get; set; }
}