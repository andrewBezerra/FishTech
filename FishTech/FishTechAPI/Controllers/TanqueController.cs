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
    public class TanqueController : ControllerBase
    {
        private readonly ITanqueRepository _TREP;

        public TanqueController(ITanqueRepository TREP)
        {
            _TREP = TREP;
        }
        [HttpGet]
        public IEnumerable<Tanque> Get()
        {
            return _TREP.List();
        }
        [HttpGet("Id")]
        public Tanque Get(int Id)
        {
            return _TREP.GetbyID(Id);
        }
        [HttpPost]
        public void Post([FromBody]Tanque tanque)
        {
            _TREP.Include(tanque);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] Tanque tanque)
        {
            _TREP.Update(tanque);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _TREP.Delete(Id);
        }
    }
}