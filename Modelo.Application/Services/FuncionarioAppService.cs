using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Modelo.Application.Interfaces;
using Modelo.Application.ViewModels;
using Modelo.Domain.Commands.Funcionario;
using Modelo.Domain.Core.Bus;
using Modelo.Domain.Interfaces.ReadOnly;

namespace Modelo.Application.Services
{
    public class FuncionarioAppService : IFuncionarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IFuncionarioReadOnlyRepository _funcionarioReadOnlyRepository;
        private readonly IMediatorHandler Bus;

        public FuncionarioAppService(IMapper mapper,
                                  IFuncionarioReadOnlyRepository funcionarioReadOnlyRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _funcionarioReadOnlyRepository = funcionarioReadOnlyRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<FuncionarioViewModel> Find(Expression<Func<FuncionarioViewModel, bool>> predicate)
        {
            //return _funcionarioReadOnlyRepository.Find().ProjectTo<FuncionarioViewModel>();
            throw new NotImplementedException();
        }

        public IEnumerable<FuncionarioViewModel> GetAll()
        {
            return _funcionarioReadOnlyRepository.GetAll().ProjectTo<FuncionarioViewModel>();
        }

        public FuncionarioViewModel GetById(Guid id)
        {
            return _mapper.Map<FuncionarioViewModel>(_funcionarioReadOnlyRepository.GetById(id));
        }

        public void Register(FuncionarioViewModel funcionarioViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewFuncionarioCommand>(funcionarioViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveFuncionarioCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(FuncionarioViewModel funcionarioViewModel)
        {
            var updateCommand = _mapper.Map<UpdateFuncionarioCommand>(funcionarioViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
