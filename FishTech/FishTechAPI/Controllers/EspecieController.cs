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
    public class EspecieController : ControllerBase
    {
        private readonly IEspecieRepository _EREP;

        public EspecieController(IEspecieRepository EREP)
        {
            _EREP = EREP;
        }
        [HttpGet]
        public IEnumerable<Especie> Get()
        {
            return _EREP.List();
        }
        [HttpGet("{Id}")]
        public Especie Get(int Id)
        {
            return _EREP.GetById(Id);
        }
        [HttpPost]
        public void Post([FromBody] Especie especie)
        {
            _EREP.Include(especie);
        }
        [HttpPut("{Id}")]
        public void Put( int Id,[FromBody] Especie especie)
        {
            _EREP.Update(especie);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _EREP.Delete(Id);
        }
    }
}