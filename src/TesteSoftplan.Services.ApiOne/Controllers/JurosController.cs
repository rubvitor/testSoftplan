using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Model;
using TesteSoftplan.Application.Interfaces;

namespace TesteSoftplan.Services.ApiOne.Controllers
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
        [Route("taxajuros")]
        public async Task<double> Get()
        {
            return await _jurosAppService.RetornaJurosFixoLocal();
        }
    }
}
