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
    public class DispositivoRepository : IDispositivoRepository
    {
        private IDB db;
        public DispositivoRepository(IDB _db)
        {
            db = _db;
        }
        public void Delete(int IdDispo)
        {
            using (var con = db.GetConnection())
            {
                var query = "delete from Dispositivo where Id= @Id";
                con.Execute(query, new { IdDispo });
            }
        }

        public IEnumerable<Dispositivo> List()
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Dispositivo";
                return con.Query<Dispositivo>(query);
            }
        }

        public Dispositivo GetbyID(int IdDispo)
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Dispositivo where IDQuestao=@IDQuestao";
                return con.QueryFirstOrDefault<Dispositivo>(query, new { IdDispo });
            }
        }

        public void Include(Dispositivo item)
        {
            using (var con = db.GetConnection())
            {
                var query = "insert into Questao (Temperatura,Ph,Oxigenio,Turbidez) values (@Temperatura,@Ph,@Oxigenio,@Turbidez)";
                con.Execute(query, new { item.Temperatura, item.Ph, item.Oxigenio, item.Turbidez });
            }
        }

        public void Update(Dispositivo item)
        {
            using (var con = db.GetConnection())
            {
                var query = "update Questao set Enunciado=@Enunciado where Id=@Id";
                con.Execute(query, new { item.Temperatura, item.Ph, item.Oxigenio, item.Turbidez, item.Id });
            }
        }
    }
}
