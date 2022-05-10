using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController : Controller
    {
        private readonly EasyToEnterDbContext _context;

        public ApplicantController(EasyToEnterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? level = null, int? science = null, int? group = null, int? direction = null)
        {
            IEnumerable<LevelFocusModel> levelfocussList = _context.LevelFocus
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f!.DirectionModel)
                .ThenInclude(d => d!.GroupModel)
                .ThenInclude(s => s!.ScienceModel);

            IEnumerable<LevelFocusModel> levelsList = levelfocussList;
            IEnumerable<LevelFocusModel> sciencesList = levelfocussList;
            IEnumerable<LevelFocusModel> groupsList = levelfocussList;
            IEnumerable<LevelFocusModel> directionsList = levelfocussList;

            if (level != null)
            {
                sciencesList = sciencesList.Where(l => l.LevelModel?.Id == level);
                groupsList = groupsList.Where(l => l.LevelModel?.Id == level);
                directionsList = directionsList.Where(l => l.LevelModel?.Id == level);
                levelfocussList = levelfocussList.Where(l => l.LevelModel?.Id == level);
            }

            if (science != null)
            {
                levelsList = levelsList.Where(l => l.FocusModel?.DirectionModel?.GroupModel?.ScienceModel?.Id == science);
                groupsList = groupsList.Where(l => l.FocusModel?.DirectionModel?.GroupModel?.ScienceModel?.Id == science);
                directionsList = directionsList.Where(l => l.FocusModel?.DirectionModel?.GroupModel?.ScienceModel?.Id == science);
                levelfocussList = levelfocussList.Where(l => l.FocusModel?.DirectionModel?.GroupModel?.ScienceModel?.Id == science);
            }

            if (group != null)
            {
                levelsList = levelsList.Where(l => l.FocusModel?.DirectionModel?.GroupModel?.Id == group);
                sciencesList = sciencesList.Where(l => l.FocusModel?.DirectionModel?.GroupModel?.Id == group);
                directionsList = directionsList.Where(l => l.FocusModel?.DirectionModel?.GroupModel?.Id == group);
                levelfocussList = levelfocussList.Where(l => l.FocusModel?.DirectionModel?.GroupModel?.Id == group);
            }

            if (direction != null)
            {
                levelsList = levelsList.Where(l => l.FocusModel?.DirectionModel?.Id == direction);
                sciencesList = sciencesList.Where(l => l.FocusModel?.DirectionModel?.Id == direction);
                groupsList = groupsList.Where(l => l.FocusModel?.DirectionModel?.Id == direction);
                levelfocussList = levelfocussList.Where(l => l.FocusModel?.DirectionModel?.Id == direction);
            }

            List<SelectListItem> levelsSelectList = levelsList.Select(g => g.LevelModel).Distinct().Select(l => new SelectListItem(l?.Name, l?.Id.ToString())).ToList();
            List<SelectListItem> sciencesSelectList = sciencesList.Select(g => g.FocusModel?.DirectionModel?.GroupModel?.ScienceModel).Distinct().Select(l => new SelectListItem(l?.Name, l?.Id.ToString())).ToList();
            List<SelectListItem> groupsSelectList = groupsList.Select(g => g.FocusModel?.DirectionModel?.GroupModel).Distinct().Select(l => new SelectListItem(l?.Name, l?.Id.ToString())).ToList();
            List<SelectListItem> directionsSelectList = directionsList.Select(g => g.FocusModel?.DirectionModel).Distinct().Select(l => new SelectListItem(l?.Name, l?.Id.ToString())).ToList();

            if (level != null)
                if (levelsSelectList.Any(l => l.Value == level.ToString()))
                    levelsSelectList.First(l => l.Value == level.ToString()).Selected = true;
            
            if (science != null)
                if (sciencesSelectList.Any(l => l.Value == science.ToString())) 
                    sciencesSelectList.First(l => l.Value == science.ToString()).Selected = true;
            
            if (group != null)
                if (groupsSelectList.Any(l => l.Value == group.ToString())) 
                    groupsSelectList.First(l => l.Value == group.ToString()).Selected = true;
            
            if (direction != null)
                if (directionsSelectList.Any(l => l.Value == direction.ToString())) 
                    directionsSelectList.First(l => l.Value == direction.ToString()).Selected = true;

            levelfocussList = levelfocussList.OrderBy(l => l.FocusModel?.DirectionModel?.GroupModel?.Code)
                .ThenBy(l => l.LevelModel?.Code)
                .ThenBy(l => l.FocusModel?.DirectionModel?.Code)
                .ThenBy(l => l.FocusModel?.Name);

            return View(new AllInfoViewModel(levelsSelectList, sciencesSelectList, groupsSelectList, directionsSelectList, levelfocussList.ToList()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}