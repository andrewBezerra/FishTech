using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class MedicaoController : Controller
    {
        private readonly IMedicaoRepository _MEDREP;

        public MedicaoController(IMedicaoRepository MEDREP)
        {
            _MEDREP = MEDREP;
        }

        public IActionResult Index()
        {
            return View(_MEDREP.List());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Medicao Medicao)
        {
            if (ModelState.IsValid)
            {
                _MEDREP.Include(Medicao);
                return View("Index", _MEDREP.List());
            }
            else
            {
                return View("Criar", Medicao);
            }
        }
        public IActionResult Editar(int Id)
        {
            return View(_MEDREP.GetbyID(Id));
        }
        [HttpPost]
        public IActionResult Editar(Medicao Medicao)
        {
            if (ModelState.IsValid)
            {
                _MEDREP.Update(Medicao);
                return View("Index", _MEDREP.List());
            }
            else
            {
                return View("Editar", Medicao);
            }
        }
    }
}
