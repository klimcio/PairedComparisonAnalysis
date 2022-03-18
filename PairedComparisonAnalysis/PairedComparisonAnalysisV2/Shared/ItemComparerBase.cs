using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using PairedComparisonAnalysisV2.Code;

namespace PairedComparisonAnalysisV2.Shared
{
    public class ItemComparerBase : ComponentBase
    {
        [CascadingParameter]
        public IModalService Modal { get; set; }

        [Parameter]
        public List<string> ItemsToCompare { get; set; }

        [Parameter]
        public ComparisonList Comparisons { get; set; }

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

            return comparison.GetPointsFor(i).ToString();
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
            var parameters = new ModalParameters();
            parameters.Add(nameof(ComparisonQuestion.Comparison), comparison);

            var comparisonModal = Modal.Show<ComparisonQuestion>("My Question is...", parameters);
            var result = await comparisonModal.Result;

            comparison.Result = result.Cancelled ? ComparisonResult.Second : ComparisonResult.First;

            Comparisons.Add(comparison);
        }
    }
}
