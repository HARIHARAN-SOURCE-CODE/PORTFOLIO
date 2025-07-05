using Microsoft.EntityFrameworkCore;
using PORTFOLIO.Models;

namespace PORTFOLIO.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op)
        { 
        
        
        }
        public DbSet<Port> Projects { get; set; }

    }
}
