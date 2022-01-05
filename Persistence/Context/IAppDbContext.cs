using Microsoft.EntityFrameworkCore;

using Domain;

namespace Persistence.Context
{
    public interface IAppDbContext
    {
        DbSet<Employee>? Employees { get; set; }

        Task<int> SaveChanges();
    }
}