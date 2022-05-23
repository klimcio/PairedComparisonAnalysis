using FluentAssertions;
using PairedComparisonAnalysisV2.Code;
using System;
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

        [Fact]
        public void WhenGettingComparisonThatIsNotExistentReturnDefaultValue()
        {
            var sut = new ComparisonList();

            Assert.Throws<ArgumentException>(() => sut["test1", "test2"]);
        }

        [Fact]
        public void GettingItemsShouldReturnTheSameItemNoMatterWhatOrderTheyArePassed()
        {
            var sut = new ComparisonList();

            sut.Add(new Comparison("test1", "test2") { Result = ComparisonResult.First });

            var result = sut["test2", "test1"];

            result.First.Should().Be("test1");
            result.Second.Should().Be("test2");
            result.Result.Should().Be(ComparisonResult.First);

            var sameResult = sut["test1", "test2"];

            sameResult.First.Should().Be("test1");
            sameResult.Second.Should().Be("test2");
            sameResult.Result.Should().Be(ComparisonResult.First);
        }
    }
}
