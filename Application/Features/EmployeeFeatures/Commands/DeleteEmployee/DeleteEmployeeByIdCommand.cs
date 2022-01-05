using MediatR;

namespace Application.Features.EmployeeFeatures.Commands.DeleteEmployee
{
    public class DeleteEmployeeByIdCommand : IRequest<Guid>
    {
        public Guid EmployeeId { get; set; }

    }
}
