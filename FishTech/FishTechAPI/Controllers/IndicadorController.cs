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

        [HttpGet("Id")]
        public Indicador Get(int Id)
        {
            return _IREP.GetbyID(Id);
        }
    }
}