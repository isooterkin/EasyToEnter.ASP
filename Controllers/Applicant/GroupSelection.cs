using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Applicant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        public IActionResult GroupSelection(int level, int science)
        {
            IEnumerable<LevelFocusModel> levelFocusCollection = _context.LevelFocus
                .Where(l => l.LevelId == level)
                .Include(l => l.LevelModel)
                .Include(lf => lf.FocusModel)
                .ThenInclude(f => f!.DirectionModel)
                .ThenInclude(d => d!.GroupModel)
                .ThenInclude(s => s!.ScienceModel)
                .Where(l => l.FocusModel!.DirectionModel!.GroupModel!.ScienceModel!.Id == science);

            return View(new GroupSelectionContainerViewModel(levelFocusCollection, level, science));
        }
    }
}