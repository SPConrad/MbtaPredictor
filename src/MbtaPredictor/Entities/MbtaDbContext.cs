using Microsoft.EntityFrameworkCore;

namespace MbtaPredictor.Entities
{
    public class MbtaDbContext : DbContext
    {
        public MbtaDbContext(DbContextOptions options) : base(options)
        {

        }

        public MbtaDbContext()
        {

        }

        public DbSet<Trip> Trips { get; set; }
    }
}
