using FishTechWebManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._Repository.Core
{
    public interface ITanqueRepository
    {
        void Include(Tanque item);
        void Update(Tanque item);
        void Delete(int Id);
        Tanque GetbyID(int Id);
        IEnumerable<Tanque> Get();
    }
}
