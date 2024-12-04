using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final3.Models;

namespace Final3.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Database context cannot be null.");
        }

        public List<Player> Players { get; set; } = new List<Player>();

        public async Task OnGetAsync()
        {
            Players = await _context.Players!.ToListAsync();
        }
    }
}
