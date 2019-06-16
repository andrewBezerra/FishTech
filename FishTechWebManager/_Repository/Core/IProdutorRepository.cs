using FishTechWebManager.Models;
using System.Collections.Generic;

namespace FishTechWebManager._Repository.Core
{
    public interface IProdutorRepository
    {
        void Include(Produtor item);
        void Update(Produtor item);
        void Delete(int Id);
        Produtor Get();
        Produtor GetbyID(int Id);
        IEnumerable<Produtor> List();
    }
}
