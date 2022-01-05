using MediatR;

namespace Application.Features.EmployeeFeatures.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Duty { get; set; } = null!;
    }
}
