﻿using EzStock.Service.Auth.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EzStock.Api.Controllers
{
    public class AuthController : MainController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public Task<string> Token([FromBody] TokenCommand command) =>
           _mediator.Send(command);
    }
}