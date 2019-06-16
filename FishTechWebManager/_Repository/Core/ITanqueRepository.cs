using FishTechWebManager.Models;
using System.Collections.Generic;

namespace FishTechWebManager._Repository.Core
{
    public interface ITanqueRepository
    {
        void Include(Tanque item);
        void Update(Tanque item);
        void Delete(int Id);
        Tanque GetbyID(int Id);
        IEnumerable<Tanque> List();
    }
}
