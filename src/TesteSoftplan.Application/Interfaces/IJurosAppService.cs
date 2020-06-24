using System;
using System.Threading.Tasks;

namespace TesteSoftplan.Application.Interfaces
{
    public interface IJurosAppService : IDisposable
    {
        Task<double> CalcJuros(double valorInicial, int tempo);
        Task<double> RetornaJurosFixoLocal();
        Task<string> CalcJuros2Round(double valorInicial, int tempo);
    }
}
