using Microsoft.AspNetCore.Components;
using PairedComparisonAnalysis.Code;
using System.Collections.Generic;
using System.Linq;

namespace PairedComparisonAnalysis.Shared
{
    public class ItemComparerBase : ComponentBase
    {
        [Parameter]
        public List<string> ItemsToCompare { get; set; }

        [Parameter]
        public List<Comparison> Comparisons { get; set; }

        [Parameter]
        public EventCallback GoPrevStep { get; set; }

        [Parameter]
        public EventCallback GoNextStep { get; set; }

        protected string GetComparisonResult(string i, string j)
        {
            var comparison = Comparisons.SingleOrDefault(x => x.First == i && x.Last == j);

            if (comparison == null)
            {
                return "_";
            }

            return comparison.Result.ToString();
        }

        protected void LaunchComparison()
        {

        }
    }
}
