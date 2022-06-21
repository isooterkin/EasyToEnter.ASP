using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VacancySelectionContainerViewModel
    {
        public readonly List<VacancyModel> VacancyList;
        public readonly List<SelectListItemSubtext> ProfessionSelectListItem;

        public VacancySelectionContainerViewModel(List<VacancyModel> vacancyList, List<SelectListItemSubtext> professionList)
        {
            VacancyList = vacancyList;
            ProfessionSelectListItem = professionList;
        }
    }
}