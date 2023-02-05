using Xunit;

namespace DesignPatternsInCsharp.Specification;

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
}