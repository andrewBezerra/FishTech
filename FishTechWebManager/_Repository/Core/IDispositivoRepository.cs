using FishTechWebManager.Models;
using System.Collections.Generic;

namespace FishTechWebManager._Repository.Core
{
    public interface IDispositivoRepository
    {
        void Include(Dispositivo item);
        void Update(Dispositivo item);
        void Delete(int Id);
        Dispositivo GetbyID(int Id);
        IEnumerable<Dispositivo> List();
    }
}
