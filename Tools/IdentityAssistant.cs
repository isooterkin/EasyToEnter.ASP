using EasyToEnter.ASP.Data;
using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace EasyToEnter.ASP.Tools
{
    public static class IdentityAssistant
    {
        public static string LastName(ClaimsPrincipal p) => p.FindFirst(x => x.Type == "LastName")?.Value?? string.Empty;



        public static string FirstName(ClaimsPrincipal p) => p.FindFirst(x => x.Type == "FirstName")?.Value ?? string.Empty;



        public static string Login(ClaimsPrincipal p) => p.FindFirst(x => x.Type == "Login")?.Value ?? string.Empty;
    }
}