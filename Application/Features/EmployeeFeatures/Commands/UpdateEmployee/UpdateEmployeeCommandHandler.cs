using Application.DTOs.Response;
using Domain;
using MediatR;

using Persistence.Context;

namespace Application.Features.EmployeeFeatures.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ApiResponseDTO<Employee>>
    {
        private readonly IAppDbContext _context;
        public UpdateEmployeeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponseDTO<Employee>> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {           
            var updatedEmployee = await UpdateAnEmployee(command);

            return updatedEmployee;
        }

        private async Task<ApiResponseDTO<Employee>> UpdateAnEmployee(UpdateEmployeeCommand command)
        {
            var employee = _context.Employees!.Where(e => e.EmployeeId == command.EmployeeId).FirstOrDefault();

            if (employee != null)
            {
                employee.FirstName = command.FirstName;
                employee.LastName = command.LastName;
                employee.PhoneNumber = command.PhoneNumber;
                employee.Position = command.Position;
                employee.Duty = command.Duty;
                employee.Department = command.Department;
                employee.Address = command.Address;
                employee.Email = command.Email;

                await _context.SaveChanges();

                return new ApiResponseDTO<Employee> { Status = 200, Message = "Employee Info Updated Successfully" };
            }

            return new ApiResponseDTO<Employee> { Status = 400, Message = "Employee not found, update failed" };

        }
    }
}
