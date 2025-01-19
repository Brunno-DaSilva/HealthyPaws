using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HealthyPaws.Dal;
using HealthyPaws.Domain;

namespace HealthyPaws.Pages.Pets;

public class EditModel : PageModel
{
    private readonly HealthyPawsDbContext dbContext;

    [BindProperty]
    public Pet? Pet { get; set; }

    public SelectList? Breeds { get; set; }

    [BindProperty]
    public IFormFile FileUpload { get; set; }

    public EditModel(HealthyPawsDbContext dbContext)
    {
        this.dbContext = dbContext;

        var breeds = dbContext
            .Breeds
            .Select(b => new SelectListItem(b.Name, b.Id.ToString())).ToList();
        Breeds = new SelectList(breeds, "Value", "Text");
    }
    public void OnGet(int id)
    {
        Pet = dbContext.Pets
                    .Where(p => p.Id == id)
                    .First();
    }

    public async Task<IActionResult> OnPost()
    {
        dbContext.Update(Pet);
        await dbContext.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}