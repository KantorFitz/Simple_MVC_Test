using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Entities;

public class Movie
{
    protected Movie()
    {
    }

    public Movie(string name, int year, int seanceTime)
    {
        Id = new Id<Movie>(Guid.NewGuid());
        Name = name;
        SeanceTime = seanceTime;
        Year = year;
    }
    
    public Id<Movie> Id { get; protected set; }
    public string Name { get; protected set; }
    public int Year { get; protected set; }
    public int SeanceTime { get; protected set; }
    public virtual ICollection<Seance> Seances { get; protected set; }

    public Seance GetSeanceByDateAndRoomId(DateTime date) => Seances.SingleOrDefault(x => $"{x.Date:dd-MM-yyyy hh:mm}" == $"{date:dd-MM-yyyy hh:mm}");

    public void SetName(string name) => Name = name;

    public void SetSeanceTime(int seanceTime) => SeanceTime = seanceTime;

    public void SetYear(int year) => Year = year;
}