using Microsoft.AspNetCore.Mvc;
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
            _context = context;
        }
        public IList<Player> Players { get; set; } = new List<Player>();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }

        public async Task OnGetAsync()
    {
           
            ViewData["NameSort"] = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            ViewData["HoursSort"] = SortOrder == "hours_asc" ? "hours_desc" : "hours_asc";

            var query = _context.Players
                .Include(p => p.GamePlayers)
                .ThenInclude(gp => gp.Game)
                .AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
{
        var searchLower = SearchString.ToLower();
        query = query.Where(p =>
        p.Name.ToLower().Contains(searchLower) ||
        p.FavoriteGame.ToLower().Contains(searchLower));
}
            query = SortOrder switch
            {
                "name_desc" => query.OrderByDescending(p => p.Name),
                "hours_asc" => query.OrderBy(p => p.HoursPlayed),
                "hours_desc" => query.OrderByDescending(p => p.HoursPlayed),
                _ => query.OrderBy(p => p.Name),
            };
            TotalPages = (int)Math.Ceiling(await query.CountAsync() / (double)PageSize);
            Players = await query.Skip((PageNum - 1) * PageSize) .Take(PageSize) .ToListAsync();
        }
    }
}
