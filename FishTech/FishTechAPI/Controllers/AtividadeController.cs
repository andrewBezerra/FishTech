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
    public class AtividadeController : ControllerBase
    {
        private readonly IAtividadeRepository _AREP;

        public AtividadeController(IAtividadeRepository AREP)
        {
            _AREP = AREP;
        }
        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return _AREP.List();
        }
        [HttpGet("{Id}")]
        public Atividade Get(int Id)
        {
            return _AREP.GetbyID(Id);
        }
        [HttpPost]
        public void Post([FromBody]Atividade atividade)
        {
            _AREP.Include(atividade);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody]Atividade atividade)
        {
            _AREP.Update(atividade);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _AREP.Delete(Id);
        }

    }
}