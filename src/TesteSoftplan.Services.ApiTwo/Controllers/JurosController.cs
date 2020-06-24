using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Model;
using TesteSoftplan.Application.Interfaces;

namespace TesteSoftplan.Services.ApiTwo.Controllers
{
    [Route("")]
    [ApiController]
    public class JurosController : ApiController
    {
        private readonly IJurosAppService _jurosAppService;
        public JurosController(IJurosAppService jurosAppService)
        {
            _jurosAppService = jurosAppService;
        }

        [HttpGet]
        [Route("calculajuros")]
        public async Task<string> Get(double valorInicial, int meses)
        {
            return await _jurosAppService.CalcJuros2Round(valorInicial, meses);
        }
    }
}
