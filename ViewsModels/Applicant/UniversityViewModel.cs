using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.ViewsModels.Applicant
{
    public class UniversityViewModel
    {
        public readonly int FocusUniversityCount; // количество программ

        public readonly int MinTuition; // стоимость обучения от ...

        public readonly int SumNumberSeats; // количество мест

        public readonly UniversityModel University; // ВУЗ

        public UniversityViewModel(List<VariabilityModel> variabilityList)
        {
            FocusUniversityCount = variabilityList.Select(v => v.FocusUniversityModel).Count();

            MinTuition = variabilityList.SelectMany(v => v.HistoryVariabilitys!).Min(hv => hv.Tuition);

            SumNumberSeats = variabilityList.SelectMany(v => v.HistoryVariabilitys!).Sum(hv => hv.NumberSeats);

            University = variabilityList.Select(v => v.FocusUniversityModel!.UniversityModel).First()!;
        }
    }
}