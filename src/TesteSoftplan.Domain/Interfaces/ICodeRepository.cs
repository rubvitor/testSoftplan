using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSoftplan.Domain.Models;
using NetDevPack.Data;

namespace TesteSoftplan.Domain.Interfaces
{
    public interface ICodeRepository
    {
        Task<string> RetornaUrlGithub();
    }
}