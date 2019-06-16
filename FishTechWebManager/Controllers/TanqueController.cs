using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class TanqueController : Controller
    {
        private readonly ITanqueRepository _TANREP;

        public TanqueController(ITanqueRepository TANREP)
        {
            _TANREP = TANREP;
        }

        public IActionResult Index()
        {
            return View(_TANREP.List());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Tanque tanque)
        {
            if (ModelState.IsValid)
            {
                _TANREP.Include(tanque);
                return View("Index", _TANREP.List());
            }
            else
            {
                return View("Criar", tanque);
            }
        }
        public IActionResult Editar(int Id)
        {
            return View(_TANREP.GetbyID(Id));
        }
        [HttpPost]
        public IActionResult Editar(Tanque tanque)
        {
            if (ModelState.IsValid)
            {
                _TANREP.Update(tanque);
                return View("Index", _TANREP.List());
            }
            else
            {
                return View("Editar", tanque);
            }
        }
    }
}