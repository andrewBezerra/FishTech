using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FishTechMobile.Models;

namespace FishTechMobile.Services
{
    public class FishTechApiService : IFishTechAPIService
    {
        public Task<Tanque> FindByIdAsync(int tanqueID, string language = "en")
        {
            return Task.FromResult(new Tanque { ID = 1, Descricao = "Tanque de Tilápias 1" });
        }

        public Task<SearchResponse<Tanque>> GetTanquesAsync(int pageNumber = 1, string language = "en")
        {
            SearchResponse<Tanque> Response = new SearchResponse<Tanque>();



            Response.PageNumber = 1;
            Response.TotalPages = 1;
            Response.TotalResults = 2;
            Response.Results = new List<Tanque> {
                new Tanque { ID = 1, Descricao = "Tanque de Tilápias 1" },
                new Tanque {ID=2,Descricao="Tanque de Tilápias 2" },
                new Tanque {ID=3,Descricao="Tanque de Tanbaqui 1" }
            };


            return Task.FromResult(Response);
        }
    }
}
