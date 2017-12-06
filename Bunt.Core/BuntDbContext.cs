using Bunt.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Bunt.Core
{
    public class BuntDbContext : DbContext
    {
        public BuntDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BuntladeStalle> BuntladeStallen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuntladeStalle>().ToTable("BuntladeStalle");
        }
    }
}