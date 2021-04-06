using Kholupov.Diploma.BookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Kholupov.Diploma.BookApp.Data
{
    public class BookAppContext : DbContext
    {
        public BookAppContext(DbContextOptions<BookAppContext> options)
            : base(options)
        {
        }

        public DbSet<BookViewModel> Books { get; set; }
    }
}
