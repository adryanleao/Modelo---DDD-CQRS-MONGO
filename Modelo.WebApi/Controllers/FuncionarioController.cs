using MediatR;
using Microsoft.AspNetCore.Mvc;
using Modelo.Application.Interfaces;
using Modelo.Application.ViewModels;
using Modelo.Domain.Core.Bus;
using Modelo.Domain.Core.Notifications;
using System;

namespace Modelo.WebApi.Controllers
{
    public class FuncionarioController : ApiControllerBase
    {
        private readonly IFuncionarioAppService _funcionarioAppService;
        public FuncionarioController(
            IFuncionarioAppService funcionarioAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _funcionarioAppService = funcionarioAppService;
        }

        [HttpGet]
        [Route("funcionarios")]
        public IActionResult Get()
        {
            return Response(_funcionarioAppService.GetAll());
        }

        [HttpGet]
        [Route("funcionarios/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var funcionarioViewModel = _funcionarioAppService.GetById(id);

            return Response(funcionarioViewModel);
        }

        [HttpPost]
        [Route("funcionarios")]
        public IActionResult Post([FromBody]FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(funcionarioViewModel);
            }

            _funcionarioAppService.Register(funcionarioViewModel);

            return Response(funcionarioViewModel);
        }

        [HttpPut]
        [Route("funcionarios")]
        public IActionResult Put([FromBody]FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(funcionarioViewModel);
            }

            _funcionarioAppService.Update(funcionarioViewModel);

            return Response(funcionarioViewModel);
        }

        [HttpDelete]
        [Route("funcionarios/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _funcionarioAppService.Remove(id);

            return Response();
        }
    }
}