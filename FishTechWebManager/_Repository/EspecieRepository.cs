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
    public class EspecieRepository : IEspecieRepository
    {
        IDB db;
        public EspecieRepository(IDB _db)
        {
            db = _db;
        }
        public void Delete(int IDEsp)
        {
            using (var con = db.GetConnection())
            {
                var query = "delete from Especie where Id=@Id";
                con.Execute(query, new { IDEsp });
            }
        }

        public Especie GetById(int Id)
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Especie where Id = @Id";
                return con.Query<Especie>(query, new { Id }).FirstOrDefault();
            }
        }

        public void Include(Especie item)
        {
            using (var con = db.GetConnection())
            {
                var query = "insert into Especie (Nome,Tanque) values (@Nome,@Tanque)";
                con.Execute(query, new { item.Nome, item.Tanque });
            }
        }

        public IEnumerable<Especie> List()
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Especie";
                return con.Query<Especie>(query);
            }
        }

        public void Update(Especie item)
        {
            using (var con = db.GetConnection())
            {
                var query = "update Especie set Nome=@Nome, Tanque=@Tanque where Id=@Id";
                con.Execute(query, new { item.Nome, item.Tanque });
            }
        }
    }
}
