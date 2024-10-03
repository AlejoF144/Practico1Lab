using Microsoft.EntityFrameworkCore;

namespace Practico1Cabaña.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { 
        
        }
    }
}
