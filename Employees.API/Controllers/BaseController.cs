﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employees.API.Controllers
{

        [ApiController]
        public abstract class BaseController : ControllerBase
        {
            private IMediator _mediator;
            protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        }
    
}
