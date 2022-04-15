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
            List<LevelFocusModel> focuss = _context.LevelFocus
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f.DirectionModel)
                .ThenInclude(d => d.GroupModel)
                .ThenInclude(s => s.ScienceModel)
                .ToList();
 
            // Уровень
            List<LevelFocusModel> levelsList = focuss;
            if (science != null) levelsList = levelsList.Where(l => l.FocusModel.DirectionModel.GroupModel.ScienceModel.Id == science).ToList();
            if (group != null) levelsList = levelsList.Where(l => l.FocusModel.DirectionModel.GroupModel.Id == group).ToList();
            if (direction != null) levelsList = levelsList.Where(l => l.FocusModel.DirectionModel.Id == direction).ToList();
            List<SelectListItem> levelsSelectList = levelsList.Select(g => g.LevelModel).Distinct().Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            if (levelsSelectList.Any(l => l.Value == level.ToString())) levelsSelectList.First(l => l.Value == level.ToString()).Selected = true;
            ViewData["Levels"] = levelsSelectList;

            // Наука
            List<LevelFocusModel> sciencesList = focuss;
            if (level != null) sciencesList = sciencesList.Where(l => l.LevelModel.Id == level).ToList();
            if (group != null) sciencesList = sciencesList.Where(l => l.FocusModel.DirectionModel.GroupModel.Id == group).ToList();
            if (direction != null) sciencesList = sciencesList.Where(l => l.FocusModel.DirectionModel.Id == direction).ToList();
            List<SelectListItem> sciencesSelectList = sciencesList.Select(g => g.FocusModel.DirectionModel.GroupModel.ScienceModel).Distinct().Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            if (sciencesSelectList.Any(l => l.Value == science.ToString())) sciencesSelectList.First(l => l.Value == science.ToString()).Selected = true;
            ViewData["Sciences"] = sciencesSelectList;

            // Группа
            List<LevelFocusModel> groupsList = focuss;
            if (level != null) groupsList = groupsList.Where(l => l.LevelModel.Id == level).ToList();
            if (science != null) groupsList = groupsList.Where(l => l.FocusModel.DirectionModel.GroupModel.ScienceModel.Id == science).ToList();
            if (direction != null) groupsList = groupsList.Where(l => l.FocusModel.DirectionModel.Id == direction).ToList();
            List<SelectListItem> groupsSelectList = groupsList.Select(g => g.FocusModel.DirectionModel.GroupModel).Distinct().Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            if (groupsSelectList.Any(l => l.Value == group.ToString())) groupsSelectList.First(l => l.Value == group.ToString()).Selected = true;
            ViewData["Groups"] = groupsSelectList;

            // Направление
            List<LevelFocusModel> directionsList = focuss;
            if (level != null) directionsList = directionsList.Where(l => l.LevelModel.Id == level).ToList();
            if (science != null) directionsList = directionsList.Where(l => l.FocusModel.DirectionModel.GroupModel.ScienceModel.Id == science).ToList();
            if (group != null) directionsList = directionsList.Where(l => l.FocusModel.DirectionModel.GroupModel.Id == group).ToList();
            List<SelectListItem> directionsSelectList = directionsList.Select(g => g.FocusModel.DirectionModel).Distinct().Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();
            if (directionsSelectList.Any(l => l.Value == direction.ToString())) directionsSelectList.First(l => l.Value == direction.ToString()).Selected = true;
            ViewData["Directions"] = directionsSelectList;

            // Направленность
            if (level != null) focuss = focuss.Where(l => l.LevelModel.Id == level).ToList();
            if (science != null) focuss = focuss.Where(l => l.FocusModel.DirectionModel.GroupModel.ScienceModel.Id == science).ToList();
            if (group != null) focuss = focuss.Where(l => l.FocusModel.DirectionModel.GroupModel.Id == group).ToList();
            if (direction != null) focuss = focuss.Where(l => l.FocusModel.DirectionModel.Id == direction).ToList();
            ViewData["Focuss"] = focuss.OrderBy(l => l.LevelId);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}