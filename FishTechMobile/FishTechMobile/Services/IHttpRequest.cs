using System.Threading.Tasks;

namespace FishTechMobile.Services
{
    public interface IHttpRequest
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
