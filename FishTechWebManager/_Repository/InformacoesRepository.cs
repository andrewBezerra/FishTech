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
    public class InformacoesRepository : IInformacoesRepository
    {
        private IDB db;
        public InformacoesRepository(IDB _db)
        {
            db = _db;
        }
        public void Delete(int IDInfo)
        {
            using (var con = db.GetConnection())
            {
                var query = "delete from Informacoes where Id = @Id";
                con.Execute(query, new { IDInfo });
            }
        }

        public IEnumerable<Informacoes> Get()
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Informacoes";
                return con.Query<Informacoes>(query);
            }
        }

        public Informacoes GetbyID(int IDInfo)
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Informacoes where Id=@Id";
                return con.QueryFirstOrDefault<Informacoes>(query, new { IDInfo });
            }
        }

        public void Include(Informacoes item)
        {
            using (var con = db.GetConnection())
            {
                var query = "insert into Informacoes (Inicio,Termino,Area,NumeroPeixes,FaseDesenvolvimento" +
                    "TipoDeRacao,GranulometriaRacao,Biomassa) " +
                    "values (@Inicio,@Termino,@Area,@NumeroPeixes,@FaseDesenvolvimento" +
                    "@TipoDeRacao,@GranulometriaRacao,@Biomassa)";
                con.Execute(query, new
                {
                    item.Id,
                    item.Inicio,
                    item.Termino,
                    item.Area,
                    item.NumeroPeixes,
                    item.FaseDesenvolvimento,
                    item.TipoDeRacao,
                    item.GranulometriaRacao,
                    item.Biomassa
                });
            }
        }

        public void Update(Informacoes item)
        {
            using (var con = db.GetConnection())
            {
                var query = "update Informacoes set Inicio=@Inicio,Termino=@Termino,Area=@Area,NumeroPeixes=@NumeroPeixes," +
                    "FaseDesenvolvimento=@FaseDesenvolvimento,TipoDeRacao=@TipoDeRacao,GranulometriaRacao=@GranulometriaRacao" +
                    "Biomassa=@Biomassa where Id=@Id";
                con.Execute(query, new
                {
                    item.Id,
                    item.Inicio,
                    item.Termino,
                    item.Area,
                    item.NumeroPeixes,
                    item.FaseDesenvolvimento,
                    item.TipoDeRacao,
                    item.GranulometriaRacao,
                    item.Biomassa
                });
            }
        }
    }
}
