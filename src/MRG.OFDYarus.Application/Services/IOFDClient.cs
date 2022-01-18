using System.Threading.Tasks;

namespace MRG.OFDYarus.Application.Services
{
    public interface IOFDClient
    {
        Task<T> PostAsync<T, R>(string url, R request);
        Task<T> PostAsync<T>(string url, object request);
    }
}
