using AutoMapper;
using Modelo.Application.ViewModels;
using Modelo.Domain.Models;

namespace Modelo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
        }
    }
}
