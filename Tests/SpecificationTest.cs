using DesignPatternsInCsharp.Specification;
using Xunit;

namespace Tests;

public class SpecificationTest
{
    [Fact]
    public void SpecificationIsSatisfiedBySubject()
    {
        // arrange
        var table = new Table(
            legs: 4, material: "Wood", type: "Scholar", size: "Medium");

        var sut = new SchoolTableSpecification();

        // act
        var result = sut.IsSatisfiedBy(table);

        // assert
        Assert.True(result);
    }
    
    [Fact]
    public void SpecificationIsNotSatisfiedBySubject()
    {
        // arrange
        var table = new Table(
            legs: 4, material: "Wood", type: "Scholar", size: "Large");

        var sut = new SchoolTableSpecification();

        // act
        var result = sut.IsSatisfiedBy(table);

        // assert
        Assert.False(result);
    }
}