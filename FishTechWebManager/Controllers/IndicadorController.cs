using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class IndicadorController : Controller
    {
        private readonly IIndicadorRepository _INDREP;

        public IndicadorController(IIndicadorRepository INDREP)
        {
            _INDREP = INDREP;
        }

        public IActionResult Index()
        {
            return View(_INDREP.List());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Indicador indicador)
        {
            if (ModelState.IsValid)
            {
                _INDREP.Include(indicador);
                return View("Index", _INDREP.List());
            }
            else
            {
                return View("Criar", indicador);
            }
        }
        public IActionResult Editar(int Id)
        {
            return View(_INDREP.GetbyID(Id));
        }
        [HttpPost]
        public IActionResult Editar(Indicador indicador)
        {
            if (ModelState.IsValid)
            {
                _INDREP.Update(indicador);
                return View("Index", _INDREP.List());
            }
            else
            {
                return View("Editar", indicador);
            }

        }
    }
}