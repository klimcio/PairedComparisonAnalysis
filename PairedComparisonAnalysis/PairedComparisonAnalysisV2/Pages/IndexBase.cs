﻿using Microsoft.AspNetCore.Components;
using PairedComparisonAnalysisV2.Code;

namespace PairedComparisonAnalysisV2.Pages
{
    public class IndexBase : ComponentBase
    {
        public List<string> Items = new List<string>();
        public ComparisonList Comparisons = new ComparisonList();

        public CurrentPage WhatPageIsThis { get; set; } = CurrentPage.EnterItems;

        protected void AddItem(string item)
        {
            Items.Add(item);
        }

        protected void GoToCollect() => WhatPageIsThis = CurrentPage.EnterItems;
        protected void GoToComparison() => WhatPageIsThis = CurrentPage.CompareItems;
        protected void GoToSummary() => WhatPageIsThis = CurrentPage.SummarizeItems;

    }
}
