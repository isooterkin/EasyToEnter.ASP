using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Services.Variability
{
    public interface IVariabilityService
    {
        Task<List<LevelFocusModel>> GetLevelFocusList();

        Task<List<FormModel>> GetFormList();

        Task<List<FormatModel>> GetFormatList();

        Task<List<PaymentModel>> GetPaymentList();
    }
}