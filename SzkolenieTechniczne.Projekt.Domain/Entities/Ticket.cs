using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Entities;

public class Ticket
{
    protected Ticket()
    {
    }

    public Ticket(string email, int peopleCount)
    {
        Id = new Id<Ticket>(Guid.NewGuid());
        Email = email;
        PeopleCount = peopleCount;
        PurchasesDate = DateTime.UtcNow;
    }

    public string Email { get; set; }
    public Id<Ticket> Id { get; set; }
    public int PeopleCount { get; set; }
    public DateTime PurchasesDate { get; set; }
    public Id<Seance> SeanceId { get; set; }
}