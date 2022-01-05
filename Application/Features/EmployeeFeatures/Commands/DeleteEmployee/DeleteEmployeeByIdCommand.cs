using Application.DTOs.Response;
using Domain;
using MediatR;

namespace Application.Features.EmployeeFeatures.Commands.DeleteEmployee
{
    public class DeleteEmployeeByIdCommand : IRequest<ApiResponseDTO<Employee>>
    {
        public Guid EmployeeId { get; set; }

    }
}
