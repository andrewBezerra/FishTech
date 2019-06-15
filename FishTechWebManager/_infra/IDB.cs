using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._infra
{
    public interface IDB : IDisposable
    {
        DbConnection GetConnection();
    }
}
