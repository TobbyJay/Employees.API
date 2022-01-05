using Domain;
using MediatR;

using Persistence.Context;

namespace Application.Features.EmployeeFeatures.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Guid>
    {
        private readonly IAppDbContext _context;
        public UpdateEmployeeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = _context.Employees!.Where(e => e.EmployeeId == command.EmployeeId).FirstOrDefault() ?? default;

            var updatedEmployee = await UpdateAnEmployee(employee,command,_context);

            return updatedEmployee;
        }

        private async Task<Guid> UpdateAnEmployee(Employee? employee, UpdateEmployeeCommand command, IAppDbContext context)
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

            return employee.EmployeeId;

        }
    }
}
