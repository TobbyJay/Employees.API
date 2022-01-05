using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public interface IAppDbContext
    {
        DbSet<Employee>? Employees { get; set; }

        Task SaveChanges();
    }
}