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
            return Task.FromResult(
                new Tanque {
                    ID = 1,
                    Descricao = "Tanque 1",
                    DataEntrada = new DateTime(2018, 12, 20),
                    EspeciePeixe = new Especie { ID = 2, Descricao = "Tilápia" },
                    Produtor = new Produtor { ID = 1, Nome = "Carlos Cicinato", UrlImagem = "https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=310.45 });
        }

        public Task<SearchResponse<Tanque>> GetTanquesAsync(int pageNumber = 1, string language = "en")
        {
            SearchResponse<Tanque> Response = new SearchResponse<Tanque>();



            Response.PageNumber = 1;
            Response.TotalPages = 1;
            Response.TotalResults = 2;
            Response.Results = new List<Tanque> {
                new Tanque {
                    ID = 1,
                    Descricao = "Tanque 1",
                    DataEntrada =new DateTime(2018,12,20),
                    EspeciePeixe =new Especie{ID=2,Descricao="Tilápia" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=310.45 },
                new Tanque {
                    ID = 2,
                    Descricao = "Tanque 2",
                    DataEntrada =new DateTime(2019,01,05),
                    EspeciePeixe =new Especie{ID=1,Descricao="Tambaqui" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=300.5 },
                new Tanque {
                    ID = 3,
                    Descricao = "Tanque 3",
                    DataEntrada =new DateTime(2018,11,14),EspeciePeixe=new Especie{ID=2,Descricao="Tilápia" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=320.56 }
            };


            return Task.FromResult(Response);
        }
    }
}
