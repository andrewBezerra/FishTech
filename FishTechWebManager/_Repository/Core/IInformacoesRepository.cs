using FishTechWebManager.Models;
using System.Collections.Generic;

namespace FishTechWebManager._Repository.Core
{
    public interface IInformacoesRepository
    {
        void Include(Informacoes item);
        void Update(Informacoes item);
        void Delete(int Id);
        Informacoes GetbyID(int Id);
        IEnumerable<Informacoes> List();

    }
}
