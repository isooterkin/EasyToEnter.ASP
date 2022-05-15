using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class VariabilitySelectionCardViewModel
    {
        public readonly VariabilityModel Variability;

        public VariabilitySelectionCardViewModel(VariabilityModel variability)
        {
            Variability = variability;
        }
    }
}