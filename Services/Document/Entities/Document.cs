namespace EncyclopediaGalactica.SourceFormats.Entities;

using System.Data.Common;

public class Document
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Uri? Uri { get; set; }
}