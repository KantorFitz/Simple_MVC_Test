using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Repository;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Cimena.Infrastructure.Repositories;

public class MoviesRepository : IMoviesRepository
{
    private readonly CinemaTicketDbContext _context;

    public MoviesRepository(CinemaTicketDbContext context)
    {
        _context = context;
    }

    public Movie GetById(Id<Movie> id)
    {
        return _context.Movies.Include(x => x.Seances).ThenInclude(x => x.Tickets).SingleOrDefault(x => x.Id == id)!;
    }

    public IEnumerable<Movie> GetAll()
    {
        return _context.Movies.ToList();
    }

    public bool IsMovieExist(string name, int year)
    {
        return _context.Movies.Any(x => x.Name == name && x.Year == year);
    }

    public bool IsSeanceExist(DateTime seanceDate)
    {
        return _context.Seances.Any(x => x.Date == seanceDate);
    }

    public void Add(Movie movie)
    {
        _context.Movies.Add(movie);
    }

    public void Update(Movie movie)
    {
        _context.Movies.Update(movie);
    }

    public Movie GetSeanceDetails(Id<Movie> movieId)
    {
        return _context.Movies.Where(x => x.Id == movieId).Include(x => x.Seances).FirstOrDefault()!;
    }

    public List<Seance> GetSeancesByMovieId(Id<Movie> movieId)
    {
        return _context.Seances.Where(x => x.MovieId == movieId).ToList();
    }

    public void Remove(Movie movie)
    {
        _context.Remove(movie);
    }
}