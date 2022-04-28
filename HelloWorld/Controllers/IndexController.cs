using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Controllers
{
    public class IndexController : Controller
    {
        private readonly Context _context;

        public IndexController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> GamesFromDB()
        {
            return View(await _context.Games.ToListAsync());
        }
    }
}
