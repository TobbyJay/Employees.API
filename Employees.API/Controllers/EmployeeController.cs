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
        private IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{employeeId}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery { Id = employeeId });
            return Ok(result);
        }

        [HttpDelete("{employeeId}", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var result = await _mediator.Send(new DeleteEmployeeByIdCommand { EmployeeId = employeeId });
            return Ok(result);
        }

        [HttpPut("{employeeId}", Name = "UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command, Guid employeeId)
        {
            if (employeeId != command.EmployeeId) return NoContent();
            
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
