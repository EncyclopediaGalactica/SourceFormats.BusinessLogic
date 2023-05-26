namespace EncyclopediaGalactica.SourceFormats.Sdk.Core.Unit.Tests;

using System;
using System.Diagnostics.CodeAnalysis;
using EncyclopediaGalactica.Sdk.Core;
using FluentAssertions;
using Xunit;

[ExcludeFromCodeCoverage]
public class CtorShould
{
    [Fact]
    public void Throw_WhenArgumentIsNull()
    {
        // Arrange and Assert
        Action action = () => { new SdkCore(null!); };

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }
}