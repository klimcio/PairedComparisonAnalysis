using FluentAssertions;
using PairedComparisonAnalysis.Code;
using Xunit;

namespace PairedComparisonAnalysis.Tests
{
    public class ComparisonListTests
    {
        [Fact]
        public void ReplaceComparisonWhenTryingToAddDuplicate()
        {
            var sut = new ComparisonList();

            sut.Add(new Comparison("test1", "test2") { Result = ComparisonResult.First });
            sut.Add(new Comparison("test1", "test2") { Result = ComparisonResult.Second });

            sut.Count.Should().Be(1);
            sut["test1", "test2"].Result.Should().Be(ComparisonResult.Second, 
                because: "we expect the value to be updated");
        }
    }
}
