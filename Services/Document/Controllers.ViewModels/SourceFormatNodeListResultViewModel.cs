namespace EncyclopediaGalactica.SourceFormats.Controllers.ViewModels;

using Dtos;

public class SourceFormatNodeListResultViewModel
{
    public bool IsOperationSuccessful { get; set; }
    public List<SourceFormatNodeDto>? Result { get; set; }
    public string? Message { get; set; }
}