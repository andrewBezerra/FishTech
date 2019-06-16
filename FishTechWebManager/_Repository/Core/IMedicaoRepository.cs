using FishTechWebManager.Models;
using System.Collections.Generic;

namespace FishTechWebManager._Repository.Core
{
    public interface IMedicaoRepository
    {
        void Include(Medicao item);
        void Update(Medicao item);
        void Delete(int Id);
        IEnumerable<Medicao> List();
        Medicao GetbyID(int Id);
    }
}
