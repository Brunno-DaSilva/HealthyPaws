using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;


namespace HealthyPaws.Pages
{
    public class LayoutModel :PageModel 
    {
         public string? EffectiveDate { get; set; }
        public int CurrentYear { get; set; }

        public void OnGet()
        {
            
          
        }
    }
}

