using Microsoft.EntityFrameworkCore;

using MediatR;

using Persistence.Context;

namespace Application.Features.EmployeeFeatures.Commands.DeleteEmployee
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdCommand, Guid>
    {
        private readonly IAppDbContext _context;
        public DeleteEmployeeByIdHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(DeleteEmployeeByIdCommand command, CancellationToken cancellationToken)
        {
            var employee = await DeleteSingleEmployee(command,_context);

            return employee;
        }

        private async Task<Guid> DeleteSingleEmployee(DeleteEmployeeByIdCommand command, IAppDbContext context)
        {
            var getEmployee = await _context.Employees!.Where(e => e.EmployeeId == command.EmployeeId).FirstOrDefaultAsync() ?? default;

            _context.Employees!.Remove(getEmployee!);
            await _context.SaveChanges();

            return getEmployee!.EmployeeId;
        }
    }
}
