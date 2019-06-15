using FishTechWebManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._Repository.Core
{
    public interface IProdutorRepository
    {
        void Include(Produtor item);
        void Update(Produtor item);
        void Delete(int Id);
        Produtor GetbyID(int Id);
        IEnumerable<Produtor> Get();
    }
}
