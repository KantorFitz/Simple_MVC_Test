using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Entities;

public class Seance
{
    protected Seance()
    {
        
    }

    public Seance(DateTime date, Id<Movie> movieId)
    {
        Id = new Id<Seance>(Guid.NewGuid());
        MovieId = movieId;
        Date = date;
    }

    public DateTime Date { get; protected set; }
    public Id<Seance> Id { get; set; }
    public Id<Movie> MovieId { get; set; }
    public virtual ICollection<Ticket> Tickets { get; protected set; }

    public List<Ticket> GetTicketByEmail(string email)
    {
        return Tickets.Where(x => x.Email == email).OrderBy(x => x.PurchasesDate).ToList();
    }

    public List<Ticket> GetAllSeanceTicket()
    {
        return Tickets == null ? new List<Ticket>() : Tickets.ToList();
    }

    public void Add(Ticket ticket)
    {
        Tickets.Add(ticket);
    }
}