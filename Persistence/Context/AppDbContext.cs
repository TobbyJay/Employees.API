using Domain;

using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Employee>? Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public async Task<int> SaveChanges() => await base.SaveChangesAsync();

    }
}
