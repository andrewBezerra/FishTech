using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacoesController : ControllerBase
    {
        private readonly IInformacoesRepository _IREP;

        public InformacoesController(IInformacoesRepository IREP)
        {
            _IREP = IREP;
        }
        [HttpGet]
        public IEnumerable<Informacoes> Get()
        {
            return _IREP.List();
        }
        [HttpGet("{Id}")]
        public Informacoes Get(int Id)
        {
            return _IREP.GetbyID(Id);
        }
        [HttpPost]
        public void Post([FromBody] Informacoes informacoes)
        {
            _IREP.Include(informacoes);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] Informacoes informacoes)
        {
            _IREP.Update(informacoes);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _IREP.Delete(Id);
        }
    }
}