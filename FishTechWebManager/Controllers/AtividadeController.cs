using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FishTechWebManager.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly IAtividadeRepository _AREP;

        public AtividadeController(IAtividadeRepository AREP)
        {
            _AREP = AREP;
        }

        public IActionResult Index()
        {
            return View(_AREP.List());
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                _AREP.Include(atividade);
                return View("Index", _AREP.List());
            }
            else
            {
                return View("Criar", atividade);
            }
        }
        public IActionResult Editar(int Id)
        {
            return View(_AREP.GetbyID(Id));
        }
        [HttpPost]
        public IActionResult Editar(Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                _AREP.Update(atividade);
                return View("Index", _AREP.List());
            }
            else
            {
                return View("Editar", atividade);
            }
        }
    }
}