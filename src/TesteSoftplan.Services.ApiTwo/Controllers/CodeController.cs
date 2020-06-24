using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteSoftplan.Domain.Interfaces;

namespace TesteSoftplan.Services.ApiTwo.Controllers
{
    [Route("")]
    [ApiController]
    public class CodeController : ApiController
    {
        private readonly ICodeRepository _codeRepository;
        public CodeController(ICodeRepository codeRepository)
        {
            _codeRepository = codeRepository;
        }

        [HttpGet]
        [Route("showmethecode")]
        public async Task<string> Get()
        {
            return await _codeRepository.RetornaUrlGithub();
        }
    }
}
