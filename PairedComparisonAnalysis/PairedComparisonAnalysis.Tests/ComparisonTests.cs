using FluentAssertions;
using PairedComparisonAnalysis.Code;
using Xunit;

namespace PairedComparisonAnalysis.Tests
{
    public class ComparisonTests
    {
        [Fact]
        public void Return_Value_Should_Differ_Based_On_Which_Perspective_We_Use()
        {
            var atla = "Avatar The Last Airbender";
            var korra = "Legend of Korra";

            var comparison = new Comparison(atla, korra)
            {
                Result = ComparisonResult.First // ATLA > Korra
            };

            comparison.GetPointsFor(atla).Should().Be(1);
            comparison.GetPointsFor(korra).Should().Be(0);
        }
    }
}
