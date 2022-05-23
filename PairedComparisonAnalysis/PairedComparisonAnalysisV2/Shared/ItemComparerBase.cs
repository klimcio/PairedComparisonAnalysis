using Microsoft.AspNetCore.Components;
using PairedComparisonAnalysisV2.Code;

namespace PairedComparisonAnalysisV2.Shared
{
    public class ItemComparerBase : ComponentBase
    {
        [Parameter]
        public List<string> ItemsToCompare { get; set; } = new List<string>();

        [Parameter]
        public ComparisonList Comparisons { get; set; } = new ComparisonList();

        [Parameter]
        public EventCallback GoPrevStep { get; set; }

        [Parameter]
        public EventCallback GoNextStep { get; set; }

        protected string GetComparisonResult(string i, string j)
        {
            var comparison = Comparisons[i, j];

            if (comparison == null)
            {
                return Comparison.NoResult;
            }

            int? comparisonPoints = comparison.GetPointsFor(i);

            return comparisonPoints.HasValue ? comparisonPoints.Value.ToString() : "";
        }

        protected void LaunchComparison()
        {
            for (int i = 0; i < ItemsToCompare.Count; i++)
            {
                for (int j = i; j < ItemsToCompare.Count; j++)
                {
                    if (i == j)
                        continue;

                    var comparison = new Comparison(ItemsToCompare[i], ItemsToCompare[j]);

                    Compare(comparison);
                }
            }

            InvokeAsync(StateHasChanged);
        }

        private async void Compare(Comparison comparison)
        {
        }
    }
}
