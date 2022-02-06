namespace PairedComparisonAnalysis.Code
{
    public class Comparison
    {
        public const string NoResult = "_";

        public string First { get; set; }
        public string Second { get; set; }
        public ComparisonResult Result { get; set; }

        public Comparison(string first, string last)
        {
            First = first;
            Second = last;
        }

        public int? GetPointsFor(string comparisonItem)
        {
            if (comparisonItem == First)
                return Result == ComparisonResult.First ? 1 : 0;

            if (comparisonItem == Second)
                return Result == ComparisonResult.Second ? 1 : 0;

            return null;
        }
    }

    public enum ComparisonResult
    {
        First,
        Second
    }
}
