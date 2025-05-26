using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace DataContext
{
    public class MoviesDbContext :DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Cast> Casts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-RDQ454BS\\SQLEXPRESS;Database='Movies'; Trusted_Connection=True; TrustServerCertificate = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity(j => j.ToTable("MovieGenres"));

            modelBuilder.Entity<Movie>()
           .HasOne(m => m.Director)
           .WithMany(d => d.Movies)
           .HasForeignKey(m => m.DirectorId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movie>()
           .HasOne(m => m.Cast)
           .WithMany(c => c.Movies)
           .HasForeignKey(m => m.CastId)
           .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
