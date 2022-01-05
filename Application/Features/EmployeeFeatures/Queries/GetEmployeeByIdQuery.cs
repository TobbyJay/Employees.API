using Microsoft.EntityFrameworkCore;

using MediatR;

using Application.DTOs.Response;
using Domain;
using Persistence.Context;

namespace Application.Features.EmployeeFeatures.Queries
{
    public class GetEmployeeByIdQuery : IRequest<ApiResponseDTO<Employee>>
    {
        public Guid Id { get; set; }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ApiResponseDTO<Employee>>
        {
            private readonly IAppDbContext _context;
            public GetEmployeeByIdQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<ApiResponseDTO<Employee>> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees!.Where(e => e.EmployeeId == query.Id).FirstOrDefaultAsync();

                if(employee == null) return new ApiResponseDTO<Employee> { Status = 404, Message = "Employee not found", Data = employee! };

                return new ApiResponseDTO<Employee> { Status = 200, Message = "Employee Info Retrieved", Data = employee! }; 
            }
         
        }
    }
}
