using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Cimena.Infrastructure;

public class CinemaTicketDbContext : DbContext
{
    public CinemaTicketDbContext(DbContextOptions<CinemaTicketDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Seance> Seances { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(m =>
        {
            m.ToTable("Movies");
            m.HasKey(x => x.Id);
            m.Property(e => e.Id).HasConversion(v => v.Value,
                v => new Id<Movie>(v));
            m.HasMany(x => x.Seances).WithOne().HasForeignKey(x => x.MovieId);
        });

        modelBuilder.Entity<Seance>(m =>
        {
            m.ToTable("Seances");
            m.HasKey(x => x.Id);
            m.Property(x => x.Id).HasConversion(x => x.Value, v => new Id<Seance>(v));
            m.Property(x => x.MovieId).HasConversion(x => x.Value, v => new Id<Movie>(v));
            m.HasMany(x => x.Tickets).WithOne().HasForeignKey(x => x.SeanceId);
        });

        modelBuilder.Entity<Ticket>(m =>
        {
            m.ToTable("Tickets");
            m.HasKey(x => x.Id);
            m.Property(x => x.Id).HasConversion(x => x.Value, v => new Id<Ticket>(v));
        });

        var firstMovie = new Movie("Harry", 2010, 150);
        var secondMovie = new Movie("Garry", 2010, 150);
        var thirdMovie = new Movie("Lolita", 2010, 150);

        modelBuilder.Entity<Movie>().HasData(firstMovie, secondMovie, thirdMovie);

        var firstDate = new DateTime(2019, 3, 10, 18, 30, 0);
        var secondDate = new DateTime(2019, 3, 10, 18, 30, 0);
        var thirdDate = new DateTime(2019, 3, 10, 18, 30, 0);

        var firstSeance = new Seance(firstDate, firstMovie.Id);
        var secondSeance = new Seance(secondDate, secondMovie.Id);
        var thirdSeance = new Seance(thirdDate, thirdMovie.Id);

        modelBuilder.Entity<Seance>().HasData(firstSeance, secondSeance, thirdSeance);
    }
}
