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
    public class IndicadorController : ControllerBase
    {
        private readonly IIndicadorRepository _IREP;

        public IndicadorController(IIndicadorRepository IREP)
        {
            _IREP = IREP;
        }
        [HttpGet]
        public IEnumerable<Indicador> Get()
        {
            return _IREP.List();
        }
        [HttpGet("Id")]
        public Indicador Get(int Id)
        {
            return _IREP.GetbyID(Id);
        }
        [HttpPost]
        public void Post([FromBody]Indicador indicador)
        {
            _IREP.Include(indicador);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] Indicador indicador)
        {
            _IREP.Update(indicador);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _IREP.Delete(Id);
        }
    }
}