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
    public class MedicaoRepository : IMedicaoRepository
    {
        //chamar indicador para usar notificacao, fazer comparativo entre medida recebida e gerar a notificacao se necessario
        IDB db;
        public MedicaoRepository(IDB _db)
        {
            db = _db;
        }
        public void Delete(int IDMed)
        {
            using (var con = db.GetConnection())
            {
                var query = "delete from Medicao where Id = @Id";
                con.Execute(query, new { IDMed });
            }
        }

        public IEnumerable<Medicao> List()
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Medicao";
                return con.Query<Medicao>(query);
            }
        }

        public Medicao GetbyID(int IDMed)
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Questao where Id=@Id";
                return con.QueryFirstOrDefault<Medicao>(query, new { IDMed });
            }
        }

        public void Include(Medicao item)
        {
            using (var con = db.GetConnection())
            {
                var query = "insert into Medicao (Medida,Indicador) values (@Medida,@Indicador)";
                con.Execute(query, new { item.Medida });
            }
        }

        public void Update(Medicao item)
        {
            using (var con = db.GetConnection())
            {
                var query = "update Medicao set Medida=@Medida, Indicador=Indicador where Id=@Id";
                con.Execute(query, new { item.Medida, item.Indicador,item.Id });
            }
        }
    }
}
