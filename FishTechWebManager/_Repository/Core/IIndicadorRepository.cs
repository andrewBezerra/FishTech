using FishTechWebManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._Repository.Core
{
    public interface IIndicadorRepository
    {
        void Include(Indicador item);
        void Update(Indicador item);
        void Delete(int Id);
        Indicador GetbyID(int Id);
        void Notificacao();
    }
}
