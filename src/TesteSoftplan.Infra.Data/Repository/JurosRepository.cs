using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSoftplan.Domain.Interfaces;
using TesteSoftplan.Domain.Models;
using Microsoft.Extensions.Options;
using TesteSoftplan.Domain.Interfaces.ApiExternal;

namespace TesteSoftplan.Infra.Data.Repository
{
    public class JurosRepository : IJurosRepository
    {
        private readonly IApiOneHttpClient _apiOneHttpClient;
        private readonly IOptions<AppSettingsConfig> _config;

        public JurosRepository(IApiOneHttpClient apiOneHttpClient, IOptions<AppSettingsConfig> config)
        {
            _apiOneHttpClient = apiOneHttpClient;
            _config = config;
        }
        public async Task<string> RetornaFormula(double valorInicial, double taxaJuros, int tempo)
        {
            var formula = _config.Value.JurosSet.Formula;
            formula = formula.Replace("{valorinicial}", valorInicial.ToString().Replace(",", "."));
            formula = formula.Replace("{juros}", taxaJuros.ToString().Replace(",", "."));
            formula = formula.Replace("{tempo}", tempo.ToString());
            formula = formula.Replace("{untempo}", _config.Value.JurosSet.TempoCalc.ToString());

            return formula;
        }

        public async Task<double> RetornaJurosFixoLocal()
        {
            return _config.Value.JurosFixo.Taxa;
        }

        public async Task<double> RetornaJurosFixoApiOne()
        {
            return await _apiOneHttpClient.GetJuros();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
