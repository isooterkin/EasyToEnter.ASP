﻿using EasyToEnter.ASP.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyToEnter.ASP.Components.Maps
{
    [ViewComponent]
    public class MapUniversityWithDormitoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(UniversityModel data) => View(data);
    }
}