using FishTechWebManager.Models;
using System.Collections.Generic;

namespace FishTechWebManager._Repository.Core
{
    public interface IIndicadorRepository
    {
        void Include(Indicador item);
        void Update(Indicador item);
        void Delete(int Id);
        IEnumerable<Indicador> List();
        Indicador GetbyID(int Id);
    }
}
