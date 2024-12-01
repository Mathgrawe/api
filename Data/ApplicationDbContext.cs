using Microsoft.EntityFrameworkCore;
using api.Models; 

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<TarefaModels> Tasks { get; set; }
        public DbSet<UserModels> Users { get; set; }
    }
}
