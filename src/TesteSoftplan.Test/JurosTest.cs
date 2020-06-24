using Microsoft.Extensions.DependencyInjection;
using System;
using TesteSoftplan.Application.Interfaces;
using TesteSoftplan.Application.Services;
using Xunit;

namespace TesteSoftplan.Test
{
    public class JurosTest: IClassFixture<InjectionFixture>
    {
        private readonly ServiceProvider _serviceProvider;

        public JurosTest(InjectionFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Theory]
        [InlineData(100, 5, "105,10")]
        public void CalculaJuros(double valor, int tempo, string calculoEsperado)
        {
            using (var service = _serviceProvider.GetService<IJurosAppService>())
            {
                var retorno = service.CalcJuros2Round(valor, tempo).Result;

                Assert.Equal(calculoEsperado, retorno);
            }
        }

        [Fact]
        public void JurosNegativos()
        {
            using (var service = _serviceProvider.GetService<IJurosAppService>())
            {
                var retorno = service.RetornaJurosFixoLocal().Result;

                Assert.True(retorno >= 0);
            }
        }
    }
}
