namespace EncyclopediaGalactica.SourceFormats.QA.Datasets;

using System.Diagnostics.CodeAnalysis;
using Dtos;

[ExcludeFromCodeCoverage]
public static class SourceFormatNodeDatasets
{
    public static IEnumerable<object?[]> AddValidationDataSet => new List<object?[]>
    {
        new object?[] { null },
        new object?[] { string.Empty },
        new object?[] { " " },
        new object?[] { "as" },
        new object?[] { "   " }
    };

    public static IEnumerable<object?[]> UpdateValidationDataSet => new List<object?[]>
    {
        new object?[] { 0, "asd" },
        new object?[] { 1, null },
        new object?[] { 1, string.Empty },
        new object?[] { 1, "  " },
        new object?[] { 1, "as" },
        new object?[] { 1, "as " },
        new object?[] { 1, "   " }
    };

    public static IEnumerable<object?[]> UpdateValidationDataSet_Without_IdIsZero => new List<object?[]>
    {
        new object?[] { 1, null },
        new object?[] { 1, string.Empty },
        new object?[] { 1, "  " },
        new object?[] { 1, "as" },
        new object?[] { 1, "as " },
        new object?[] { 1, "   " }
    };

    public static IEnumerable<object[]?> Service_AddChildToParentAsync_NullInput_Dataset =>
        new List<object[]?>
        {
            new object?[] { null, null },
            new object?[] { new SourceFormatNodeDto(), null },
            new object?[] { null, new SourceFormatNodeDto() },
        };

    public static IEnumerable<object[]?> Service_AddChildToParentAsync_InvalidInput_Dataset =>
        new List<object[]?>
        {
            new object?[]
            {
                new SourceFormatNodeDto { Id = 0 },
                new SourceFormatNodeDto { Id = 100 }
            },
            new object?[]
            {
                new SourceFormatNodeDto { Id = 100 },
                new SourceFormatNodeDto { Id = 0 }
            },
            new object?[]
            {
                new SourceFormatNodeDto { Id = 100 },
                new SourceFormatNodeDto { Id = 100 }
            }
        };

    public static IEnumerable<object?[]> SDKModels_AddChildToParent_InputValidation_Dataset =>
        new List<object?[]>
        {
            new object?[] { 0, 0 },
            new object?[] { 1, 0 },
            new object?[] { 0, 1 },
        };
}