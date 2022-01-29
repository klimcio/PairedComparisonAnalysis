using System.Collections.Generic;
using System.Linq;

namespace PairedComparisonAnalysis.Code
{
    public class Comparison
    {
        public string First { get; set; }
        public string Last { get; set; }

        // 1 means First > Last, 0 means First < Last
        public int Result { get; set; }
    }

    //public class ComparisonList
    //{
    //    public List<Comparison> Comparisons { get; set; } = new List<Comparison>();

    //    public void Add(int i, int j)
    //    {

    //    }

    //    public Comparison this[int i, int j]
    //    {
    //        get
    //        {
    //            return Comparisons.SingleOrDefault();
    //        }
    //    }

    //    private bool ComparisonExists(int i, int j)
    //    {

    //    }
    //}
}
