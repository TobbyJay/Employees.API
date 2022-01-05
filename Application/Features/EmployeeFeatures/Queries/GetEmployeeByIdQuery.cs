using MediatR;

using Entities;
using Entities.Context;

namespace Application.Features.EmployeeFeatures.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid EmployeeId { get; set; }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
        {
            private readonly AppDbContext _context;
            public GetEmployeeByIdQueryHandler(AppDbContext context)
            {
                _context = context;
            }
            public async Task<Employee> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                var employee = _context.Employees!.Where(e => e.EmployeeId == query.EmployeeId).FirstOrDefault() ?? null;

                return employee!;
            }
        }
    }
}
