namespace EncyclopediaGalactica.Services.Document.Tests.Datasets.Document;

using System.Collections;
using Dtos;

public class UpdateDocumentInputValidationInvalidDataset : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new DocumentDto
            {
                Id = 0,
                Name = "name",
                Description = "description"
            }
        };
        yield return new object[]
        {
            new DocumentDto
            {
                Id = 1,
                Name = string.Empty,
                Description = "description"
            }
        };
        yield return new object[]
        {
            new DocumentDto
            {
                Id = 1,
                Name = null,
                Description = "description"
            }
        };
        yield return new object[]
        {
            new DocumentDto
            {
                Id = 1,
                Name = "na",
                Description = "description"
            }
        };
        yield return new object[]
        {
            new DocumentDto
            {
                Id = 1,
                Name = "na ",
                Description = "description"
            }
        };
        yield return new object[]
        {
            new DocumentDto
            {
                Id = 1,
                Name = "   ",
                Description = "description"
            }
        };
        yield return new object[]
        {
            new DocumentDto
            {
                Id = 1,
                Name = "name",
                Description = null
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}