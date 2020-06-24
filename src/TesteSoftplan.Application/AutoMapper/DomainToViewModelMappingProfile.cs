using AutoMapper;
using TesteSoftplan.Application.ViewModels;
using TesteSoftplan.Domain.Models;

namespace TesteSoftplan.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Juros, JurosViewModel>();
        }
    }
}
