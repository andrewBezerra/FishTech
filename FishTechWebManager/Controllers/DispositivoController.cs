using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class DispositivoController : Controller
    {
        private readonly IDispositivoRepository _DISREP;

        public DispositivoController(IDispositivoRepository DISREP)
        {
            _DISREP = DISREP;
        }

        public IActionResult Index()
        {
            return View(_DISREP.List());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                _DISREP.Include(dispositivo);
                return View("Index", _DISREP.List());
            }
            else
            {
                return View("Criar", dispositivo);
            }
        }
        public IActionResult Editar(int Id)
        {
            return View(_DISREP.GetbyID(Id));
        }
        [HttpPost]
        public IActionResult Editar(Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                _DISREP.Update(dispositivo);
                return View("Index", _DISREP.List());
            }
            else
            {
                return View("Editar", dispositivo);
            }
        }
    }
}
