using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class InformacoesController : Controller
    {
        private readonly IInformacoesRepository _INFOREP;

        public InformacoesController(IInformacoesRepository INFOREP)
        {
            _INFOREP = INFOREP;
        }

        public IActionResult Index()
        {
            return View(_INFOREP.List());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Informacoes Informacoes)
        {
            if (ModelState.IsValid)
            {
                _INFOREP.Include(Informacoes);
                return View("Index", _INFOREP.List());
            }
            else
            {
                return View("Criar", Informacoes);
            }
        }
        public IActionResult Editar(int Id)
        {
            return View(_INFOREP.GetbyID(Id));
        }
        [HttpPost]
        public IActionResult Editar(Informacoes Informacoes)
        {
            if (ModelState.IsValid)
            {
                _INFOREP.Update(Informacoes);
                return View("Index", _INFOREP.List());
            }
            else
            {
                return View("Editar", Informacoes);
            }
        }
    }
}