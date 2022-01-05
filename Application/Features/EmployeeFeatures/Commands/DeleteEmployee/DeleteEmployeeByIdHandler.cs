using Microsoft.EntityFrameworkCore;

using MediatR;

using Persistence.Context;
using Application.Exceptions;
using Application.DTOs.Response;
using Domain;

namespace Application.Features.EmployeeFeatures.Commands.DeleteEmployee
{
    public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeByIdCommand, ApiResponseDTO<Employee>>
    {
        private readonly IAppDbContext _context;
        public DeleteEmployeeByIdHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponseDTO<Employee>> Handle(DeleteEmployeeByIdCommand command, CancellationToken cancellationToken)
        {
            var employee = await DeleteSingleEmployee(command);

            return employee;
        }

        private async Task<ApiResponseDTO<Employee>> DeleteSingleEmployee(DeleteEmployeeByIdCommand command)
        {
            var getEmployee = await _context.Employees!.Where(e => e.EmployeeId == command.EmployeeId).FirstOrDefaultAsync();

            if (getEmployee == null) return new ApiResponseDTO<Employee> { Status = 404, Message = "Employee Not Found", Data = null!};

            _context.Employees!.Remove(getEmployee!);
            await _context.SaveChanges();

            return new ApiResponseDTO<Employee> { Status = 200,Message = "Employee Deleted Successfully", Data = null! };
        }
    }
}
