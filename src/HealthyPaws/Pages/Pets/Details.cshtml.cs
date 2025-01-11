using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthyPaws.Dal;
using HealthyPaws.Domain;

namespace HealthyPaws.Pages.Pets;

public class DetailsModel : PageModel
{
    private readonly HealthyPawsDbContext dbContext;

    public Pet? Pet { get; set; }
    public DetailsModel(HealthyPawsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void OnGet(int? id)
    {
        var pet = dbContext.Pets
            .Where(p => p.Id == id)
            .Include(p => p.Owners)
            .Include(p => p.Breed)
            .ThenInclude(b => b.Species)
            .First();

        Pet = pet;
    }
}