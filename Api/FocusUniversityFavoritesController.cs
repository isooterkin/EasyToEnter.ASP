using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Authorization;

// https://stackoverflow.com/questions/36280947/how-to-pass-multiple-parameters-to-a-get-method-in-asp-net-core/36300901#36300901
// https://stackoverflow.com/questions/36280947/how-to-pass-multiple-parameters-to-a-get-method-in-asp-net-core/36287271#36287271
// https://stackoverflow.com/questions/17832784/how-to-get-post-data-in-webapi
// https://stackoverflow.com/questions/36280947/how-to-pass-multiple-parameters-to-a-get-method-in-asp-net-core

namespace EasyToEnter.ASP.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FocusUniversityFavoritesController : ControllerBase
    {
        private readonly EasyToEnterDbContext _context;

        public FocusUniversityFavoritesController(EasyToEnterDbContext context)
        {
            _context = context;
        }



        // POST: api/FocusUniversityFavorites/add?personId=&focusUniversityId=
        [HttpPost("add/")]
        public async Task<IActionResult> AddFocusUniversityFavorites([FromQuery(Name = "personId")] int personId, [FromQuery(Name = "focusUniversityId")] int focusUniversityId)
        {
            _context.FocusUniversityFavorites.Add(new FocusUniversityFavoritesModel()
            {
                PersonId = personId,
                FocusUniversityId = focusUniversityId
            });

            await _context.SaveChangesAsync();

            return NoContent();
        }



        // POST: api/FocusUniversityFavorites/delete?focusUniversityFavoritesId=
        [HttpPost("delete/")]
        public async Task<IActionResult> DeleteFocusUniversityFavorites([FromQuery(Name = "focusUniversityFavoritesId")] int focusUniversityFavoritesId)
        {
            if (_context.FocusUniversityFavorites == null) return NotFound();

            FocusUniversityFavoritesModel? focusUniversityFavoritesModel = await _context.FocusUniversityFavorites.FindAsync(focusUniversityFavoritesId);

            if (focusUniversityFavoritesModel == null) return NotFound();

            _context.FocusUniversityFavorites.Remove(focusUniversityFavoritesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
