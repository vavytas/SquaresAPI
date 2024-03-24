using Microsoft.EntityFrameworkCore;
using SquaresAPIHomework.Entities;

namespace SquaresAPIHomework.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<OnePoint> Points { get; set; }

    }
}
