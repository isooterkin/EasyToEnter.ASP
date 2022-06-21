using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VacancySelectionContainerViewModel
    {
        public readonly List<VacancyFavoritesViewModel> VacancyFavoritesViewModelList;
        public readonly List<SelectListItemSubtext> ProfessionSelectListItem;

        public VacancySelectionContainerViewModel(List<VacancyFavoritesViewModel> vacancyFavoritesViewModelList, List<SelectListItemSubtext> professionList)
        {
            VacancyFavoritesViewModelList = vacancyFavoritesViewModelList;
            ProfessionSelectListItem = professionList;
        }
    }
}