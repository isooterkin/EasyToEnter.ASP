using EasyToEnter.ASP.Data;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Controllers
{
    public class MyController: Controller
    {
        private protected readonly EasyToEnterDbContext _context;
        public MyController(EasyToEnterDbContext context) => _context = context;



        private protected bool CheckIdentity() => User != null && User.Identity != null && User.Identity.IsAuthenticated == true;
    }
}