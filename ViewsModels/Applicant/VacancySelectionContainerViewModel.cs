using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VacancySelectionContainerViewModel
    {
        public readonly List<VacancyFavoritesViewModel> VacancyFavoritesViewModelList;
        public readonly List<SelectListItemSubtext> ProfessionSelectListItem;
        public readonly int MinWages;
        public readonly int MaxWages;
        public readonly int SelectMinWages;
        public readonly int SelectMaxWages;

        public VacancySelectionContainerViewModel(List<VacancyFavoritesViewModel> vacancyFavoritesViewModelList, 
            List<SelectListItemSubtext> professionList, int minWages, int maxWages, 
            int selectMinWages, int selectMaxWages)
        {
            VacancyFavoritesViewModelList = vacancyFavoritesViewModelList;
            ProfessionSelectListItem = professionList;
            MinWages = minWages;
            MaxWages = maxWages;
            SelectMinWages = selectMinWages;
            SelectMaxWages = selectMaxWages;
        }
    }
}