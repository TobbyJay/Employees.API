
using Domain;
using MediatR;
using Persistence.Context;

namespace Application.Features.EmployeeFeatures.Commands.CreateEmployee
{

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
        {
            private readonly IAppDbContext _context;
            public CreateEmployeeCommandHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = await CreateNewEmployee(command, _context);

                return employee;
            }

            private async Task<Guid> CreateNewEmployee(CreateEmployeeCommand command, IAppDbContext _context)
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

                return createEmployee.EmployeeId;
            }
        }
    
}
