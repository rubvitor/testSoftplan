using System.Net.Http;
using System.Threading.Tasks;

namespace TesteSoftplan.Domain.Interfaces.ApiExternal
{
    public interface IApiOneHttpClient
    {
        HttpClient Client { get; }

        Task<double> GetJuros();
    }
}