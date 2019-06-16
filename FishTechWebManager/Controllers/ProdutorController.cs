using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class ProdutorController : Controller
    {
        private readonly IProdutorRepository _PRODREP;

        public ProdutorController(IProdutorRepository PRODREP)
        {
            _PRODREP = PRODREP;
        }

        public IActionResult Index()
        {
            return View(_PRODREP.List());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Produtor Produtor)
        {
            if (ModelState.IsValid)
            {
                _PRODREP.Include(Produtor);
                return View("Editar", _PRODREP.GetbyID(Produtor.Id));
            }
            else
            {
                return View("Criar", Produtor);
            }
        }
        public IActionResult Editar(int Id)
        {
            return View(_PRODREP.GetbyID(Id));
        }
        [HttpPost]
        public IActionResult Editar(Produtor Produtor)
        {
            if (ModelState.IsValid)
            {
                _PRODREP.Update(Produtor);
                return View("Index", _PRODREP.List());
            }
            else
            {
                return View("Editar", Produtor);
            }
        }
    }
}
