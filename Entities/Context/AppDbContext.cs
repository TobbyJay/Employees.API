using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee>? Employees { get; set; }

        public async Task SaveChanges() => await base.SaveChangesAsync();
    }
}
