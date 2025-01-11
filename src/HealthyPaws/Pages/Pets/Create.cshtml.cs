using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HealthyPaws.Dal;
using HealthyPaws.Domain;

namespace HealthyPaws.Pages.Pets;

public class CreateModel : PageModel
{
    private readonly HealthyPawsDbContext dbContext;

    [BindProperty]
    public Pet? Pet { get; set; }

    public SelectList? Breeds { get; set; }

    public CreateModel(HealthyPawsDbContext dbContext)
    {
        this.dbContext = dbContext;

        var breeds = dbContext
           .Breeds
           .Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        Breeds = new SelectList(breeds, "Value", "Text");
    }

    public async Task<IActionResult> OnPostAsync()
    {
        dbContext.Pets.Add(Pet);
        await dbContext.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}