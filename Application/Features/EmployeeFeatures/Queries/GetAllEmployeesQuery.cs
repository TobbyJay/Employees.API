using Microsoft.EntityFrameworkCore;

using MediatR;

using Domain;
using Persistence.Context;

namespace Application.Features.EmployeeFeatures.Queries
{
    public partial class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {
            private readonly IAppDbContext _context;
            public GetAllEmployeesHandler(IAppDbContext context)
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
