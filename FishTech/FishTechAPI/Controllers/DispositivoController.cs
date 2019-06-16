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
    public class DispositivoController : ControllerBase
    {
        private readonly IDispositivoRepository _DREP;

        public DispositivoController(IDispositivoRepository DREP)
        {
            _DREP = DREP;
        }
        [HttpGet]
        public IEnumerable<Dispositivo> Get()
        {
            return _DREP.List();
        }
        [HttpGet("{Id}")]
        public Dispositivo Get(int Id)
        {
            return _DREP.GetbyID(Id);
        }
        [HttpPost]
        public void Post([FromBody] Dispositivo dispositivo)
        {
            _DREP.Include(dispositivo);
        }
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] Dispositivo dispositivo)
        {
            _DREP.Update(dispositivo);
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _DREP.Delete(Id);
        }
    }
}