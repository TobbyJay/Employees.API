using Microsoft.EntityFrameworkCore;

using MediatR;

using Entities;
using Entities.Context;

namespace Application.Features.EmployeeFeatures.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {
            private readonly AppDbContext _context;
            public GetAllEmployeesHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {

                var employees = await _context.Employees!.ToListAsync() ?? null;

                return employees!.AsReadOnly();
                
            }
        }
    }
}
