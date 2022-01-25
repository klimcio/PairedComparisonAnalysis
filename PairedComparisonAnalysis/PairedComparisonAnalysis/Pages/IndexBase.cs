using Microsoft.AspNetCore.Components;
using PairedComparisonAnalysis.Code;
using System.Collections.Generic;

namespace PairedComparisonAnalysis.Pages
{
    public class IndexBase : ComponentBase
    {
        public List<string> Items = new List<string>();
        public CurrentPage WhatPageIsThis { get; set; } = CurrentPage.EnterItems;

        protected void AddItem(string item)
        {
            Items.Add(item);
        }

        protected void NextStep()
        {
            WhatPageIsThis = CurrentPage.CompareItems;
        }
    }
}
