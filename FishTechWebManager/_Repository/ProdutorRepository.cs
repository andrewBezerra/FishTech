using Dapper;
using FishTechWebManager._infra;
using FishTechWebManager._Repository.Core;
using FishTechWebManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTechWebManager._Repository
{
    public class ProdutorRepository : IProdutorRepository
    {
        IDB db;
        public ProdutorRepository(IDB _db)
        {
            db = _db;
        }
        public void Delete(int IDProd)
        {
            using (var con = db.GetConnection())
            {
                var query = "delete from Produtor where Id=@Id";
                con.Execute(query, new { IDProd });
            }
        }

        public IEnumerable<Produtor> List()
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Produtor";
                return con.Query<Produtor>(query);
            }
        }

        public Produtor GetbyID(int IDProd)
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Produtor where Id=@Id";
                return con.QueryFirstOrDefault<Produtor>(query, new { Id = IDProd });
            }
        }

        public void Include(Produtor item)
        {
            using (var con = db.GetConnection())
            {
                var query = "insert into Produtor (Nome) values (@Nome)";
                con.Execute(query, new { item.Nome });
            }
        }

        public void Update(Produtor item)
        {
            using (var con = db.GetConnection())
            {
                var query = "update Produtor set Nome=@Nome where Id=@Id";
                con.Execute(query, new { item.Nome, item.Id });
            }
        }

        public Produtor Get()
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Produtor ";
                return con.QueryFirstOrDefault<Produtor>(query);
            }
        }
    }
}
