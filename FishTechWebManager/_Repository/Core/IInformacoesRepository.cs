using FishTechWebManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._Repository.Core
{
    public interface IInformacoesRepository
    {
        void Include(Informacoes item);
        void Update(Informacoes item);
        void Delete(int Id);
        Informacoes GetbyID(int Id);
        IEnumerable<Informacoes> Get();

    }
}
