using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IList<Player>? Players { get; set; }

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
            ViewData["LevelSort"] = SortOrder == "level_asc" ? "level_desc" : "level_asc";

            var playersQuery = _context.Players
                .Include(p => p.GamePlayers)
                .ThenInclude(gp => gp.Game)
                .AsQueryable();

            playersQuery = SortOrder switch
            {
                "name_desc" => playersQuery.OrderByDescending(p => p.Name),
                "level_asc" => playersQuery.OrderBy(p => p.CurrentLevel),
                "level_desc" => playersQuery.OrderByDescending(p => p.CurrentLevel),
                _ => playersQuery.OrderBy(p => p.Name),
            };

            if (!string.IsNullOrEmpty(SearchString))
            {
                playersQuery = playersQuery.Where(p =>
                    p.Name != null &&
                    p.Name.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }

            TotalPages = (int)Math.Ceiling(await playersQuery.CountAsync() / (double)PageSize);

            Players = await playersQuery
                .Skip((PageNum - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
