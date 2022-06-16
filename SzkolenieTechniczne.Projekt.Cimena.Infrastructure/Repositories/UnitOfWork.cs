using SzkolenieTechniczne.Projekt.Domain.Repository;

namespace SzkolenieTechniczne.Projekt.Cimena.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CinemaTicketDbContext _context;

    public UnitOfWork(CinemaTicketDbContext context)
    {
        _context = context;
        MoviesRepository = new MoviesRepository(context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IMoviesRepository MoviesRepository { get; }
    public void Commit()
    {
        _context.SaveChanges();
    }
}