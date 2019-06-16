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
    public class MedicaoController : ControllerBase
    {
        private readonly IMedicaoRepository _MREP;

        public MedicaoController(IMedicaoRepository MREP)
        {
            _MREP = MREP;
        }
        [HttpGet]
        public IEnumerable<Medicao> Get()
        {
            return _MREP.List();
        }
        [HttpGet("{Id}")]
        public Medicao Get(int Id)
        {
            return _MREP.GetbyID(Id);
        }
        [HttpPost]
        public void Post([FromBody] Medicao medicao)
        {
            _MREP.Include(medicao);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] Medicao medicao)
        {
            _MREP.Update(medicao);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _MREP.Delete(Id);
        }
    }
}