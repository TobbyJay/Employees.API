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
        [Route("api/employee")]

        public async Task<IActionResult> Employees()
        {
            var result = await Mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("api/create")]

        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/getemployee/{employeeId}")]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            var result = await Mediator.Send(new GetEmployeeByIdQuery { Id = employeeId });
            return Ok(result);
        }

        [HttpGet]
        [Route("api/deleteemployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var result = await Mediator.Send(new DeleteEmployeeByIdCommand { EmployeeId = employeeId });
            return Ok(result);
        }

        [HttpGet]
        [Route("api/updateemployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command, Guid employeeId)
        {
            if (employeeId != command.EmployeeId) return NoContent();
            
            var result = await Mediator.Send(command);
            return Ok(result);
        }

    }
}
