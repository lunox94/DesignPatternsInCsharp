using DesignPatternsInCsharp.Specification;
using Xunit;

namespace Tests;

public class SpecificationTest
{
    [Theory]
    [InlineData(4, "Wood", "Scholar", "Small")]
    [InlineData(4, "Wood", "Scholar", "Medium")]
    [InlineData(4, "Plastic", "Scholar", "Medium")]
    public void SpecificationIsSatisfiedBySubject(int legs, string material,
        string type, string size)
    {
        // arrange
        var table = new Table(legs, material, type, size);

        var sut = new SchoolTableSpecification();

        // act
        var result = sut.IsSatisfiedBy(table);

        // assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(4, "Wood", "Scholar", "Large")]
    [InlineData(3, "Wood", "Scholar", "Large")]
    [InlineData(4, "Plastic", "Workbench", "Medium")]
    [InlineData(4, "Glass", "Scholar", "Medium")]
    public void SpecificationIsNotSatisfiedBySubject(int legs, string material,
        string type, string size)
    {
        // arrange
        var table = new Table(
            legs, material, type, size);

        var sut = new SchoolTableSpecification();

        // act
        var result = sut.IsSatisfiedBy(table);

        // assert
        Assert.False(result);
    }
}