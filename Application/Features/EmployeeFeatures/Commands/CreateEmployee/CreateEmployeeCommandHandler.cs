using MediatR;

using Domain;

using Persistence.Context;
using Application.DTOs.Response;

namespace Application.Features.EmployeeFeatures.Commands.CreateEmployee
{

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ApiResponseDTO<Employee>>
        {
            private readonly IAppDbContext _context;
            public CreateEmployeeCommandHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<ApiResponseDTO<Employee>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = await CreateNewEmployee(command);

                return employee;
            }

           

            private async Task<ApiResponseDTO<Employee>> CreateNewEmployee(CreateEmployeeCommand command)
            {
                var createEmployee = new Employee();

                createEmployee.FirstName = command.FirstName;
                createEmployee.LastName = command.LastName;
                createEmployee.PhoneNumber = command.PhoneNumber;
                createEmployee.Position = command.Position;
                createEmployee.Duty = command.Duty;
                createEmployee.Department = command.Department;
                createEmployee.Address = command.Address;
                createEmployee.Email = command.Email;

                _context.Employees!.Add(createEmployee);
                await _context.SaveChanges();

                return new ApiResponseDTO<Employee> { Status = 200, Message = "Employee Created Successfully"};
            }
        }
    
}
