using FishTechMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FishTechMobile.Services
{
    public interface IFishTechAPIService
    {
        Task<SearchResponse<Tanque>> GetTanquesAsync(int pageNumber = 1, string language = "en");
        Task<Tanque> FindByIdAsync(int tanqueID, string language = "en");
    }
}
