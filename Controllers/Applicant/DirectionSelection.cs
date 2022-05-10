using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult DirectionSelection(int level, int group)
        {
            IEnumerable<LevelFocusModel> levelFocusCollection = _context.LevelFocus
                .Where(l => l.LevelId == level)
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f!.DirectionModel)
                .ThenInclude(d => d!.GroupModel)
                .Where(l => l.FocusModel!.DirectionModel!.GroupModel!.Id == group);

            return View(new DirectionSelectionContainerViewModel(levelFocusCollection, level, group));
        }
    }
}