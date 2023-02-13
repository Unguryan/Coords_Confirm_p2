using ConfirmCoords.EF_Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace ConfirmCoords.EF_Core.Context
{
    public class CoordContext : DbContext
    {
        public CoordContext(DbContextOptions<CoordContext> options) : base(options)
        {
        }

        public DbSet<CoordDbo> Coords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SubmitCoords.db");
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoordDbo>().ToTable("Coords");
        }
    }
}
