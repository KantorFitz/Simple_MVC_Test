using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Query.DTO;

public class TicketDetailsDTO
{
	public string Email { get; set; }
	public Id<Ticket> Id { get; set; }
	public int PeopleCount { get; set; }
	public DateTime PurchasesDate { get; set; }

	public TicketDetailsDTO(string email, Id<Ticket> id, int peopleCount, DateTime purchasesDate)
	{
		Email = email;
		Id = id;
		PeopleCount = peopleCount;
		PurchasesDate = purchasesDate;
	}
}