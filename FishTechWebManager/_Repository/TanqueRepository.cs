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
    public class TanqueRepository : ITanqueRepository
    {
        private IDB db;
        public TanqueRepository(IDB _db)
        {
           db = _db;
        }

        public void Delete(int IDTan)
        {
            using (var con = db.GetConnection())
            {
                var query = "delete from Tanque where Id=@Id";
                con.Execute(query, new { IDTan });
            }
        }

        public IEnumerable<Tanque> List()
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Tanque";
                return con.Query<Tanque>(query);
            }
        }

        public Tanque GetbyID(int IDTan)
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Tanque where Id=@Id";
                return con.QueryFirstOrDefault<Tanque>(query, new { IDTan });
            }
        }

        public void Include(Tanque item)
        {
            using (var con = db.GetConnection())
            {
                var query = "insert into Tanque (Dispositivo,Atividade,Produtor,Medicao,Informacoes) " +
                    "values (@Dispositivo,@Atividade,@Produtor,@Medicao,@Informacoes)";
                con.Execute(query, new { item.Dispositivo, item.Atividade, item.Produtor, item.Medicao, item.Informacoes });
            }
        }

        public void Update(Tanque item)
        {
            using (var con = db.GetConnection())
            {
                var query = "update Tanque set Dispositivo=@Dispositivo,Atividade=@Atividade,Produtor=@Produtor," +
                    "Medicao=@Medicao,Informacoes=@Informacoes where Id=@Id";
                con.Execute(query, new {
                    item.Dispositivo,
                    item.Atividade,
                    item.Produtor,
                    item.Medicao,
                    item.Informacoes
                });
            }
        }
    }
}
