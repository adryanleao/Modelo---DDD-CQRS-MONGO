
using AutoMapper;
using Modelo.Application.ViewModels;
using Modelo.Domain.Commands.Funcionario;

namespace Modelo.Application.AutoMapper
{
    class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<FuncionarioViewModel, RegisterNewFuncionarioCommand>()
                .ConstructUsing(c => new RegisterNewFuncionarioCommand(c.Nome, c.Email, c.DataAniversario));
            CreateMap<FuncionarioViewModel, UpdateFuncionarioCommand>()
                .ConstructUsing(c => new UpdateFuncionarioCommand(c.Id, c.Nome, c.Email, c.DataAniversario));
        }
    }
}
