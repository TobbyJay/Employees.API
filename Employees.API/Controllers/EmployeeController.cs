using System.Net;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using Application.Features.EmployeeFeatures.Commands.CreateEmployee;
using Application.Features.EmployeeFeatures.Queries;
using Application.Features.EmployeeFeatures.Commands.DeleteEmployee;
using Application.Features.EmployeeFeatures.Commands.UpdateEmployee;

namespace Employees.API.Controllers
{
    [ApiController]
    public class EmployeeController : BaseController
    {
       

        [HttpGet]
        public async Task<IActionResult> Employees()
        {
            var result = await Mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{employeeId}", Name = "GetEmployee")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var result = await Mediator.Send(new GetEmployeeByIdQuery { Id = employeeId });
            return Ok(result);
        }

        [HttpDelete("{employeeId}", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var result = await Mediator.Send(new DeleteEmployeeByIdCommand { EmployeeId = employeeId });
            return Ok(result);
        }

        [HttpPut("{employeeId}", Name = "UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command, Guid employeeId)
        {
            if (employeeId != command.EmployeeId) return NoContent();
            
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
