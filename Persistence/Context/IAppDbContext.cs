using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public interface IAppDbContext
    {
        DbSet<Employee>? Employees { get; set; }

        Task<int> SaveChanges();
    }
}