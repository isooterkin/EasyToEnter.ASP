using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public class ApplicantController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public ApplicantController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        // Открытие страницы
        public IActionResult Index(int? level = null, int? science = null, int? group = null, int? direction = null)
        {
            IEnumerable<LevelFocusModel> focuss = _context.LevelGroup
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f.DirectionModel)
                .ThenInclude(d => d.GroupModel)
                .ThenInclude(s => s.ScienceModel);

            List<SelectListItem> levels = _context.Level.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            if (levels.Any(l => l.Value == level.ToString())) levels.First(l => l.Value == level.ToString()).Selected = true;
            ViewData["Levels"] = levels;

            List<SelectListItem> sciences = _context.Science.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            if (sciences.Any(l => l.Value == science.ToString())) sciences.First(l => l.Value == science.ToString()).Selected = true;
            ViewData["Sciences"] = sciences;

            List<SelectListItem> groups = _context.Group.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name,
            }).ToList();
            if (groups.Any(l => l.Value == group.ToString())) groups.First(l => l.Value == group.ToString()).Selected = true;
            ViewData["Groups"] = groups;

            List<SelectListItem> directions = _context.Direction.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name,
            }).ToList();
            if (directions.Any(l => l.Value == direction.ToString())) directions.First(l => l.Value == direction.ToString()).Selected = true;
            ViewData["Directions"] = directions;

            if (level != null) focuss = focuss.Where(l => l.LevelModel.Id == level);
            if (science != null) focuss = focuss.Where(l => l.FocusModel.DirectionModel.GroupModel.ScienceModel.Id == science);
            if (group != null) focuss = focuss.Where(l => l.FocusModel.DirectionModel.GroupModel.Id == group);
            if (direction != null) focuss = focuss.Where(l => l.FocusModel.DirectionModel.Id == direction);

            ViewData["Focuss"] = focuss.ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}