using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSoftplan.Domain.Interfaces;
using TesteSoftplan.Domain.Models;
using Microsoft.Extensions.Options;

namespace TesteSoftplan.Infra.Data.Repository
{
    public class CodeRepository : ICodeRepository
    {
        private readonly IOptions<AppSettingsConfig> _config;

        public CodeRepository(IOptions<AppSettingsConfig> config)
        {
            _config = config;
        }
        public async Task<string> RetornaUrlGithub()
        {
            return _config.Value.Github.UrlProjeto;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
