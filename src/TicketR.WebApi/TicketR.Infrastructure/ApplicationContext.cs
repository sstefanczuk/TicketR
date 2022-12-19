using Microsoft.EntityFrameworkCore;
using TicketR.Domain.Entities;

namespace TicketR.Infrastructure
{
    internal class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<TestEntity> TestEntities { get; set; }
    }
}
