using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Tools
{
    public static class PredictorHistory
    {
        public static HistoryVariabilityModel Predict(List<HistoryVariabilityModel> historyVariabilityList)
        {
            return new HistoryVariabilityModel 
            {
                Year = DateTime.Now.Year + 1,
                Tuition = (int) (historyVariabilityList.Average(hv => hv.Tuition) * 1.1),
                NumberSeats = (int) (historyVariabilityList.Average(hv => hv.NumberSeats) * 1.1),
                PassingGrade = (int) (historyVariabilityList.Average(hv => hv.PassingGrade) * 1.1)
            };
        }
    }
}