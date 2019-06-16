using FishTechWebManager.Models;
using System.Collections.Generic;

namespace FishTechWebManager._Repository.Core
{
    public interface IAtividadeRepository
    {
        void Include(Atividade item);
        void Update(Atividade item);
        void Delete(int Id);
        Atividade GetbyID(int Id);
        IEnumerable<Atividade> List();
    }
}
