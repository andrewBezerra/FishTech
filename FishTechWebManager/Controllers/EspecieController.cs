using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class EspecieController : Controller
    {
        private readonly IEspecieRepository _EREP;

        public EspecieController(IEspecieRepository EREP)
        {
            _EREP = EREP;
        }

        public IActionResult Index()
        {
            return View(_EREP.List());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Especie Especie)
        {
            if (ModelState.IsValid)
            {
                _EREP.Include(Especie);
                return View("Index", _EREP.List());
            }
            else
            {
                return View("Criar", Especie);
            }
        }
        public IActionResult Editar(int Id)
        {
            return View(_EREP.GetById(Id));
        }
        [HttpPost]
        public IActionResult Editar(Especie Especie)
        {
            if (ModelState.IsValid)
            {
                _EREP.Update(Especie);
                return View("Index", _EREP.List());
            }
            else
            {
                return View("Editar", Especie);
            }
        }
    }
}
