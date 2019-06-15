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
    public class IndicadorRepository : IIndicadorRepository
    {
        IDB db;
        public IndicadorRepository(IDB _db)
        {
            db = _db;
        }
        public void Delete(int IDInd)
        {
            using (var con = db.GetConnection())
            {
                var query = "delete from Indicador where Id=@Id";
                con.Execute(query, new { IDInd });
            }
        }

        public Indicador GetbyID(int IDInd)
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Indicador where Id=@Id";
                return con.QueryFirstOrDefault<Indicador>(query, new { IDInd });
            }
        }

        public void Include(Indicador item)
        {
            using (var con = db.GetConnection())
            {
                var query = "insert into Indicador (Titulo,FaixaDe,FaixaAte,PontoOtimo,Especie)" +
                    " values (@Titulo,@FaixaDe,@FaixaAte,@PontoOtimo,@Especie)";
                con.Execute(query, new { item.Titulo, item.FaixaDe, item.FaixaAte, item.PontoOtimo, item.Especie });
            }
        }

        public void Notificacao()
        {
            //implantar método notificação para gerar mensagem para valores < ou valores > para determinado indicador
        }

        public void Update(Indicador item)
        {
            using (var con = db.GetConnection())
            {
                var query = "update Indicador set Titulo=@Titulo, FaixaDe=@FaixaDe, FaixaAte=@FaixaAte," +
                    "PontoOtimo=@PontoOtimo, Especie=@Especia where Id=@Id";
                con.Execute(query, new { item.Titulo,item.FaixaDe, item.FaixaAte, item.PontoOtimo, item.Especie, item.Id });
            }
        }
    }
}
