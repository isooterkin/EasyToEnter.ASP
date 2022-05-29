using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Components.Maps
{
    public class UniversityViewModel
    {
        public readonly UniversityModel University;

        public UniversityViewModel(UniversityModel university)
        {
            University = university;
        }
    }
}