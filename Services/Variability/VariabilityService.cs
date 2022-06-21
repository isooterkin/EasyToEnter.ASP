using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Services.Variability
{
    public class VariabilityService: IVariabilityService
    {
        private readonly EasyToEnterDbContext Context;

        public VariabilityService(EasyToEnterDbContext context) => Context = context;

        public async Task<List<LevelFocusModel>> GetLevelFocusList() => await Context.LevelFocus
            .Include(lf => lf.LevelModel)
            .Include(lf => lf.FocusModel!.DirectionModel!.GroupModel!.ScienceModel)
            .ToListAsync();

        public async Task<List<FormModel>> GetFormList() => await Context.Form
            .ToListAsync();

        public async Task<List<FormatModel>> GetFormatList() => await Context.Format
            .ToListAsync();

        public async Task<List<PaymentModel>> GetPaymentList() => await Context.Payment
            .ToListAsync();
    }
}