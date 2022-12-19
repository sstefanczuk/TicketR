using Microsoft.EntityFrameworkCore;

namespace TicketR.Domain
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
