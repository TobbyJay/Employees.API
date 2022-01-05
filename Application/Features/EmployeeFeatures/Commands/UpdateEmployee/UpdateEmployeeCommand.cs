using Application.DTOs.Response;
using Domain;
using MediatR;

namespace Application.Features.EmployeeFeatures.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<ApiResponseDTO<Employee>>
    {
        public Guid EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
        public string? Duty { get; set; }
    }
    
}
