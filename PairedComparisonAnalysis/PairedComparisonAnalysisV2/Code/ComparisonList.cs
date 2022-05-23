namespace PairedComparisonAnalysisV2.Code
{
    public class ComparisonList
    {
        public List<Comparison> Comparisons { get; set; } = new List<Comparison>();

        public int Count => Comparisons.Count;

        public void Add(Comparison newComparison)
        {
            var itemIndex = GetIndex(newComparison.First, newComparison.Second);

            if (itemIndex == -1)
            {
                Comparisons.Add(newComparison);
            }
            else
            {
                this[newComparison.First, newComparison.Second] = newComparison;
            }
        }

        public Comparison this[string i, string j]
        {
            get
            {
                var index = GetIndex(i, j);

                if (index == -1)
                    throw new ArgumentException();

                return Comparisons[index];
            }
            private set
            {
                var index = GetIndex(i, j);

                Comparisons[index] = value;
            }
        }

        private int GetIndex(string i, string j)
        {
            return Comparisons.FindIndex(ComparePredicate(i, j));
        }

        private Predicate<Comparison> ComparePredicate(string i, string j)
            => x => x.First == i && x.Second == j || x.First == j && x.Second == i;
    }
}
