using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Repository;

public interface IMoviesRepository
{
    Movie GetById(Id<Movie> id);
    IEnumerable<Movie> GetAll();
    bool IsMovieExist(string name, int year);
    bool IsSeanceExist(DateTime seanceDate);
    void Add(Movie movie);
    void Update(Movie movie);
    Movie GetSeanceDetails(Id<Movie> movieId);
    List<Seance> GetSeancesByMovieId(Id<Movie> movieId);
    void Remove(Movie movie);
}