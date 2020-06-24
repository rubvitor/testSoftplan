using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSoftplan.Domain.Models;
using NetDevPack.Data;

namespace TesteSoftplan.Domain.Interfaces
{
    public interface IJurosRepository
    {
        Task<string> RetornaFormula(double valorInicial, double taxaJuros, int tempo);
        Task<double> RetornaJurosFixoApiOne();
        Task<double> RetornaJurosFixoLocal();
    }
}