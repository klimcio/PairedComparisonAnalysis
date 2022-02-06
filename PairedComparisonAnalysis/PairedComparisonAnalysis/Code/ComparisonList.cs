using System;
using System.Collections.Generic;
using System.Linq;

namespace PairedComparisonAnalysis.Code
{
    public class ComparisonList
    {
        public List<Comparison> Comparisons { get; set; } = new List<Comparison>();

        public int Count => Comparisons.Count;

        public void Add(Comparison newComparison)
        {
            var item = this[newComparison.First, newComparison.Second];

            if (item == null)
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
                return Comparisons.SingleOrDefault(CompareByOrder(i, j));
            }
            private set
            {
                var index = Comparisons.FindIndex(ComparePredicate(i, j));

                Comparisons[index] = value;
            }
        }

        private Predicate<Comparison> ComparePredicate(string i, string j) 
            => x => (x.First == i && x.Second == j) || (x.First == j && x.Second == i);

        private Func<Comparison, bool> CompareByOrder(string i, string j) 
            => x => (x.First == i && x.Second == j) || (x.First == j && x.Second == i);
    }
}
