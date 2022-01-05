using Entities;
using Entities.Context;
using MediatR;

namespace Application.Features.EmployeeFeatures.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly AppDbContext _context;
        public CreateEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public Task<Guid> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = CreateNewEmployee(command, _context);

            return employee;
        }

        private async Task<Guid> CreateNewEmployee(CreateEmployeeCommand command, AppDbContext _context)
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
            await _context.SaveChangesAsync();

            return createEmployee.EmployeeId;
        }
    }
}
