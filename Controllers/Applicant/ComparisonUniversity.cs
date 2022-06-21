using EasyToEnter.ASP.Models.Models;
using EasyToEnter.ASP.Tools.Authorization;
using EasyToEnter.ASP.Tools.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyToEnter.ASP.Controllers.Applicant
{
    public partial class ApplicantController
    {
        [Authorized]
        public async Task<IActionResult> ComparisonUniversityAsync()
        {
            // Избранные вариативности
            List<UniversityFavoritesModel> universityFavoritesList = await _context.UniversityFavorites
                .Where(uf => uf.PersonId == User.Id())
                .Include(uf => uf.UniversityModel!.Dormitorys)
                .Include(uf => uf.UniversityModel!.AddressModel!.CityModel!.RegionModel)
                .Include(uf => uf.UniversityModel!.AccreditationModel)
                .Include(uf => uf.UniversityModel!.SpecializationUniversitys!)
                    .ThenInclude(sp => sp.SpecializationModel)
                .Include(uf => uf.UniversityModel!.FocusUniversitys!)
                    .ThenInclude(fu => fu.Variabilitys!)
                        .ThenInclude(v => v.HistoryVariabilitys)
                .Include(vf => vf.PersonModel) // ???
                .ToListAsync();

            return View(universityFavoritesList);
        }
    }
}