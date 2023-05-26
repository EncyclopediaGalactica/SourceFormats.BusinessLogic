namespace EncyclopediaGalactica.SourceFormats.QA.Datasets;

using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class DocumentDataset
{
    public static IEnumerable<object[]> Add_Validation = new List<object[]>
    {
        new object[]{1, "name", "desc", new Uri("https://asd.com")},
        new object[]{0, string.Empty, "desc", new Uri("https://asd.com")},
        new object[]{0, null, "desc", new Uri("https://asd.com")},
        new object[]{0, "na", "desc", new Uri("https://asd.com")},
        new object[]{0, "   ", "desc", new Uri("https://asd.com")},
        new object[]{0, "name", string.Empty, new Uri("https://asd.com")},
    };
}