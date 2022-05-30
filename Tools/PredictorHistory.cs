using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Tools
{
    public static class PredictorHistory
    {
        public static HistoryVariabilityModel Predict(List<HistoryVariabilityModel> historyVariabilityList)
        {
            if (!historyVariabilityList.Any()) return new HistoryVariabilityModel 
            {
                Year = DateTime.Now.Year + 1
            };

            return new HistoryVariabilityModel 
            {
                Year = DateTime.Now.Year + 1,
                Tuition = (int) (historyVariabilityList.Average(hv => hv.Tuition) * 1.1),
                NumberSeats = (int) (historyVariabilityList.Average(hv => hv.NumberSeats) * 1.1),
                PassingGrade = (int) (historyVariabilityList.Average(hv => hv.PassingGrade) * 1.1)
            };
        }

        public static HistoryVariabilityModel DePredict(List<HistoryVariabilityModel> historyVariabilityList, int i)
        {
            if (!historyVariabilityList.Any()) return new HistoryVariabilityModel
            {
                Year = DateTime.Now.Year - i
            };

            var counthistoryVariabilityList = historyVariabilityList.Count - 1;

            return new HistoryVariabilityModel
            {
                Year = historyVariabilityList[counthistoryVariabilityList].Year - (counthistoryVariabilityList + i),
                Tuition = (int) (historyVariabilityList.Average(hv => hv.Tuition) * (1 - i * 0.1)),
                NumberSeats = (int) (historyVariabilityList.Average(hv => hv.NumberSeats) * (1 - i * 0.1)),
                PassingGrade = (int) (historyVariabilityList.Average(hv => hv.PassingGrade) * (1 - i * 0.1))
            };
        }
    }
}