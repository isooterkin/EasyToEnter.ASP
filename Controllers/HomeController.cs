using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EasyToEnter.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public HomeController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Вывести группы Бакалавра
            var allGroup = _context.LevelFocus.Where(l => l.LevelId == 1)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f.DirectionModel)
                .ThenInclude(d => d.GroupModel)
                .Select(g => g.FocusModel.DirectionModel.GroupModel.Name)
                .Distinct()
                .ToList();

            return View();
        }




















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}