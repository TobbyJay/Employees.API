using System.Net;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using Application.Features.EmployeeFeatures.Commands.CreateEmployee;
using Application.Features.EmployeeFeatures.Queries;
using Application.Features.EmployeeFeatures.Commands.DeleteEmployee;
using Application.Features.EmployeeFeatures.Commands.UpdateEmployee;

namespace Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        [HttpPost(Name = "CreateEmployee")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(_mediator.Send(result));
        }

       
        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("{employeeId}", Name = "GetEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery { EmployeeId = employeeId });
            return Ok(result);
        }

        [HttpGet("{employeeId}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var result = await _mediator.Send(new DeleteEmployeeByIdCommand { EmployeeId = employeeId });
            return Ok(result);
        }

        [HttpGet("{employeeId}", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command, Guid employeeId)
        {
            if (employeeId != command.EmployeeId) return NoContent();
            
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
