using Microsoft.EntityFrameworkCore;

using MediatR;

using Entities.Context;

namespace Application.Features.EmployeeFeatures.Commands.DeleteEmployee
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdCommand, Guid>
    {
        private readonly AppDbContext _context;
        public DeleteEmployeeByIdHandler(AppDbContext context)
        {
            _context = context;
        }
        public Task<Guid> Handle(DeleteEmployeeByIdCommand command, CancellationToken cancellationToken)
        {
            var employee = DeleteSingleEmployee(command,_context);

            return employee;
        }

        private async Task<Guid> DeleteSingleEmployee(DeleteEmployeeByIdCommand command, AppDbContext context)
        {
            var getEmployee = await _context.Employees!.Where(e => e.EmployeeId == command.EmployeeId).FirstOrDefaultAsync() ?? default;

            _context.Employees!.Remove(getEmployee!);
            await _context.SaveChangesAsync();

            return getEmployee.EmployeeId;
        }
    }
}
