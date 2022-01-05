using MediatR;

using Application.DTOs.Response;
using Domain;

namespace Application.Features.EmployeeFeatures.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<ApiResponseDTO<Employee>>
    {
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
