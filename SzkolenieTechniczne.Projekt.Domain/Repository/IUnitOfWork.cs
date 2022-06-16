namespace SzkolenieTechniczne.Projekt.Domain.Repository;

public interface IUnitOfWork : IDisposable
{
    IMoviesRepository MoviesRepository { get; }
    void Commit();
}