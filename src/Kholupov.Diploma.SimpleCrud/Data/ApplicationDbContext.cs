using Kholupov.Diploma.SimpleCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace Kholupov.Diploma.SimpleCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<ApplicationType> ApplicationType { get; set; }
    }
}
