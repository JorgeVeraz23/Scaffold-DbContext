using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class AplicationDbContext: DbContext 
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }
    }
}
