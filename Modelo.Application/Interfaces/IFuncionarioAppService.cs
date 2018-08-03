using Modelo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Modelo.Application.Interfaces
{
    public interface IFuncionarioAppService : IDisposable
    {
        void Register(FuncionarioViewModel funcionarioViewModel);
        IEnumerable<FuncionarioViewModel> GetAll();
        FuncionarioViewModel GetById(Guid id);
        IEnumerable<FuncionarioViewModel> Find(Expression<Func<FuncionarioViewModel, bool>> predicate);
        void Update(FuncionarioViewModel funcionarioViewModel);
        void Remove(Guid id);
    }
}
