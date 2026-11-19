using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using wt_lab5_5razor_antonov.Data;
using wt_lab5_5razor_antonov.Models;

namespace wt_lab5_5razor_antonov.Pages.Cars;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    public IndexModel(AppDbContext context) => _context = context;

    public IList<Car> Cars { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        var query = _context.Cars.AsQueryable();
        if (!string.IsNullOrWhiteSpace(Search))
        {
            query = query.Where(c => c.Brand.Contains(Search) || c.Model.Contains(Search));
        }
        Cars = await query.OrderBy(c => c.Brand).ToListAsync();
    }
}