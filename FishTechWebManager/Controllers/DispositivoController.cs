﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class DispositivoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}