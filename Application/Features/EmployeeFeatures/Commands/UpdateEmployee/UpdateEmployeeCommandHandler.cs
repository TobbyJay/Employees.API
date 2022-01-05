using MediatR;

using Entities.Context;
using Entities;

namespace Application.Features.EmployeeFeatures.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Guid>
    {
        private readonly AppDbContext _context;
        public UpdateEmployeeCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = _context.Employees!.Where(e => e.EmployeeId == command.EmployeeId).FirstOrDefault() ?? default;

            var updatedEmployee = await UpdateAnEmployee(employee,command,_context);

            return updatedEmployee;
        }

        private async Task<Guid> UpdateAnEmployee(Employee? employee, UpdateEmployeeCommand command, AppDbContext context)
        {

            employee.FirstName = command.FirstName;
            employee.LastName = command.LastName;
            employee.PhoneNumber = command.PhoneNumber;
            employee.Position = command.Position;
            employee.Duty = command.Duty;
            employee.Department = command.Department;
            employee.Address = command.Address;
            employee.Email = command.Email;

            await _context.SaveChangesAsync();

            return employee.EmployeeId;

        }
    }
}
