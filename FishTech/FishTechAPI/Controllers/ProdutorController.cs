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
    public class ProdutorController : ControllerBase
    {
        private readonly IProdutorRepository _PREP;

        public ProdutorController(IProdutorRepository PREP)
        {
            _PREP = PREP;
        }
        [HttpGet]
        public IEnumerable<Produtor> Get()
        {
            return _PREP.List();
        }
        [HttpGet("{Id}")]
        public Produtor Get(int Id)
        {
            return _PREP.GetbyID(Id);
        }
        [HttpPost]
        public void Post([FromBody] Produtor produtor)
        {
            _PREP.Include(produtor);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] Produtor produtor)
        {
            _PREP.Update(produtor);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _PREP.Delete(Id);
        }
    }
}