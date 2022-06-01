using EasyToEnter.ASP.Models.Models;

namespace EasyToEnter.ASP.Services.Discipline
{
    public interface IDisciplineService
    {
        Task<List<DisciplineModel>> GetDisciplineList();
    }
}