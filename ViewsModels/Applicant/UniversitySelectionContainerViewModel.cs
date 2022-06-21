using EasyToEnter.ASP.ViewsModels.Components;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class UniversitySelectionContainerViewModel
    {
        public readonly List<UniversityFavoritesViewModel> UniversityFavoritesViewModelList;
        public readonly List<SelectListItemSubtext> AccreditationSelectListItem;
        public readonly List<SelectListItemSubtext> MilitaryDepartmentSelectListItem;
        public readonly List<SelectListItemSubtext> DormitoryDepartmentSelectListItem;
        public readonly List<SelectListItemSubtext> SpecializationSelectListItem;



        public UniversitySelectionContainerViewModel(List<UniversityFavoritesViewModel> universityFavoritesViewModel, List<SelectListItemSubtext> accreditationSelectListItem,
            List<SelectListItemSubtext> militaryDepartmentSelectListItem, List<SelectListItemSubtext> dormitoryDepartmentSelectListItem,
            List<SelectListItemSubtext> specializationSelectListItem)
        {
            UniversityFavoritesViewModelList = universityFavoritesViewModel;
            AccreditationSelectListItem = accreditationSelectListItem;
            MilitaryDepartmentSelectListItem = militaryDepartmentSelectListItem;
            DormitoryDepartmentSelectListItem = dormitoryDepartmentSelectListItem;
            SpecializationSelectListItem = specializationSelectListItem;
        }
    }
}