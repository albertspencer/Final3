using Microsoft.AspNetCore.Mvc.RazorPages;
using Final3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Final3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        
        public List<Game> Games { get; set; } = new List<Game>();

        public void OnGet()
        {
            
            Games = _context.Games.ToList();
        }
    }
}
