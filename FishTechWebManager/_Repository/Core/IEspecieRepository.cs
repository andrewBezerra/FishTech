using FishTechWebManager.Models;
using System.Collections.Generic;

namespace FishTechWebManager._Repository.Core
{
    public interface IEspecieRepository
    {
        void Include(Especie item);
        void Update(Especie item);
        void Delete(int Id);
        IEnumerable<Especie> List();
        Especie GetById(int Id);
    }
}
