using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishTechMobile.Models;

namespace FishTechMobile.Services
{
    public class FishTechApiService : IFishTechAPIService
    {
        private List<Tanque> Tanques  = new List<Tanque> {
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
                    DataEntrada =new DateTime(2018,11,14),EspeciePeixe=new Especie{ID=2,Descricao="Tambaqui" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=320.56 },
                new Tanque {
                    ID = 4,
                    Descricao = "Tanque 4",
                    DataEntrada =new DateTime(2018,11,14),EspeciePeixe=new Especie{ID=2,Descricao="Tilápia" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=320.56 },
                new Tanque {
                    ID = 5,
                    Descricao = "Tanque 5",
                    DataEntrada =new DateTime(2018,11,14),EspeciePeixe=new Especie{ID=2,Descricao="Tilápia" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=320.56 },
                new Tanque {
                    ID = 6,
                    Descricao = "Tanque 6",
                    DataEntrada =new DateTime(2018,11,14),EspeciePeixe=new Especie{ID=2,Descricao="Tilápia" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=320.56 },
                new Tanque {
                    ID = 7,
                    Descricao = "Tanque 7",
                    DataEntrada =new DateTime(2018,11,14),EspeciePeixe=new Especie{ID=2,Descricao="Caranha" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=320.56 },
                new Tanque {
                    ID = 8,
                    Descricao = "Tanque 8",
                    DataEntrada =new DateTime(2018,11,14),EspeciePeixe=new Especie{ID=2,Descricao="Caranha" },
                    Produtor =new Produtor{ID=1,Nome="Carlos Cicinato",UrlImagem="https://www.suasorquideas.com/wp-content/uploads/2019/01/IMG_8822-768x768.jpg" },
                    Biomassa=320.56 },
            };
        public Task<Tanque> FindByIdAsync(int tanqueID, string language = "en")
        {
            return  Task.FromResult(Tanques.Where(X=>X.ID==tanqueID).First());
        }

        public Task<SearchResponse<Tanque>> GetTanquesAsync(int pageNumber = 1, string language = "en")
        {
            SearchResponse<Tanque> Response = new SearchResponse<Tanque>();



            Response.PageNumber = 1;
            Response.TotalPages = 1;
            Response.TotalResults = 2;
            Response.Results = Tanques;


            return Task.FromResult(Response);
        }
    }
}
