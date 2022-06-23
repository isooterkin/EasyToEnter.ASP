using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EasyToEnter.ASP.Controllers.Administrator
{
    public class AdministratorController : Controller
    {
        private readonly EasyToEnterDbContext _context;
        public AdministratorController(EasyToEnterDbContext context) => _context = context;



        public IActionResult Index()
        {
            List<string?>? tableNames = _context.Model.GetEntityTypes()
                .Select(t => t.GetTableName())
                .Distinct()
                .ToList();

            return View(tableNames);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}