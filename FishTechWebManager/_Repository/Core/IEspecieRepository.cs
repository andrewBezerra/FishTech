using FishTechWebManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._Repository.Core
{
    public interface IEspecieRepository
    {
        void Include(Especie item);
        void Update(Especie item);
        void Delete(int Id);
    }
}
