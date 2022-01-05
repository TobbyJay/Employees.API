using Domain;
using MediatR;
using Persistence.Context;

namespace Application.Features.EmployeeFeatures.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
        {
            private readonly IAppDbContext _context;
            public GetEmployeeByIdQueryHandler(IAppDbContext context)
            {
                _context = context;
            }
            public async Task<Employee> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                var employee = _context.Employees!.Where(e => e.EmployeeId == query.Id).FirstOrDefault() ?? null;

                return employee!;
            }
        }
    }
}
