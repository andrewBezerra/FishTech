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
    public class AtividadeRepository : IAtividadeRepository
    {
        private IDB db;
        public AtividadeRepository(IDB _db)
        {
            db = _db;
        }
        public void Delete(int IDAtividade)
        {
            using (var con = db.GetConnection())
            {
                var query = "delete from Informacoes where Id = @Id";
                con.Execute(query, new { IDAtividade });
            }
        }


        public void Include(Atividade item)
        {
            using (var con = db.GetConnection())
            {
                var query = "insert into Informacoes (Titulo,Agendamento,Acao) " +
                    "values (@Titulo,@Agendamento,@Acao)";
                con.Execute(query, new
                {
                    item.Id,
                    item.Titulo,
                    item.Agendamento,
                    item.Acao
                });
            }
        }


        public void Update(Atividade item)
        {
            using (var con = db.GetConnection())
            {
                var query = "update Informacoes set Titulo=@Titulo,Agendamento=@Agendamento,Acao=@Acao where Id=Id";
                con.Execute(query, new
                {
                    item.Id,
                    item.Titulo,
                    item.Agendamento,
                    item.Acao
                });
            }
        }

        IEnumerable<Atividade> IAtividadeRepository.Get()
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Informacoes";
                return con.Query<Atividade>(query);
            }
        }

        Atividade IAtividadeRepository.GetbyID(int IDAtividade)
        {
            using (var con = db.GetConnection())
            {
                var query = "select * from Informacoes where Id=@Id";
                return con.QueryFirstOrDefault<Atividade>(query, new { IDAtividade });
            }
        }
    }
}
