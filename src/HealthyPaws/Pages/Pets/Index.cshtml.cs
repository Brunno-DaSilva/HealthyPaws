using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthyPaws.Dal;
using HealthyPaws.Domain;

namespace HealthyPaws.Pages.Pets;

public class IndexModel : PageModel
{
    private readonly HealthyPawsDbContext dbContext;

    public IEnumerable<Pet>? Pets { get; private set; }

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public IndexModel(HealthyPawsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void OnGet()
    {
        Pets = dbContext.Pets
            .Include(p => p.Breed)
            .ThenInclude(b => b.Species)
            .Where(p => string.IsNullOrWhiteSpace(Search) ? true :
                    p.Name.ToLowerInvariant().Contains(Search))
            .ToList();
    }
}