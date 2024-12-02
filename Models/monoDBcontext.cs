using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class monoDBcontext : DbContext
    {
        public monoDBcontext(DbContextOptions<monoDBcontext> options) : base(options)
        {
        
        }
        public DbSet<mono> Monotcrest { get; set; }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
