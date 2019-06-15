using FishTechWebManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._Repository.Core
{
    public interface IDispositivoRepository
    {
        void Include(Dispositivo item);
        void Update(Dispositivo item);
        void Delete(int Id);
        Dispositivo GetbyID(int Id);
        IEnumerable<Dispositivo> Get();
    }
}
