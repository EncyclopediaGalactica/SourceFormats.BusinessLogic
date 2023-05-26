namespace EncyclopediaGalactica.SourceFormats.SourceFormatsService.Int.Tests.Document;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dtos;
using Entities;
using FluentAssertions;
using FluentValidation;
using QA.Datasets;
using Xunit;

[ExcludeFromCodeCoverage]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Add_Validation_Should : BaseTest
{
    [Fact]
    public void Throw_WhenInput_IsNull()
    {
        // Arrange && Act
        Func<Task> f = async () =>
        {
            await Sut.DocumentService.AddAsync(null!);
        };
    }

    [Theory]
    [MemberData(nameof(DocumentDataset.Add_Validation), MemberType = typeof(DocumentDataset))]
    public void Throw_ValidationException_WhenInput_IsInvalid(
        long id,
        string name,
        string desc,
        Uri uri)
    {
        // Arrange && Act
        Func<Task> f = async () =>
        {
            await Sut.DocumentService.AddAsync(new DocumentDto
            {
                Id = id,
                Name = name,
                Description = desc,
                Uri = uri
            });
        };

        // Assert
        f.Should().ThrowExactlyAsync<ValidationException>();
    }
}