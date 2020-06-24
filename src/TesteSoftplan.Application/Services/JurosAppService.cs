using System;
using System.Threading.Tasks;
using TesteSoftplan.Application.Interfaces;
using TesteSoftplan.Domain.Interfaces;
using org.mariuszgromada.math.mxparser;
using System.Linq;

namespace TesteSoftplan.Application.Services
{
    public class JurosAppService : IJurosAppService
    {
        private readonly IJurosRepository _jurosrRepository;

        public JurosAppService(IJurosRepository jurosrRepository)
        {
            _jurosrRepository = jurosrRepository;
        }
        public async Task<double> CalcJuros(double valorInicial, int tempo)
        {
            var taxaJuros = await _jurosrRepository.RetornaJurosFixoApiOne();
            var formula = await _jurosrRepository.RetornaFormula(valorInicial, taxaJuros, tempo);

            Expression ex = new Expression(formula);
            var calculado =  ex.calculate();

            return calculado;
        }

        public async Task<string> CalcJuros2Round(double valorInicial, int tempo)
        {
            var juros = await CalcJuros(valorInicial, tempo);
            var jurosParse = juros.ToString("#.##").Replace(".", ",");
            var splitJuros = jurosParse.Split(',');

            if (splitJuros.Length <= 1)
                return splitJuros.FirstOrDefault();

            if (splitJuros.LastOrDefault().Length == 2)
                return jurosParse;

            return $"{jurosParse}0";
        }

        public async Task<double> RetornaJurosFixoLocal()
        {
            return await _jurosrRepository.RetornaJurosFixoLocal();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
