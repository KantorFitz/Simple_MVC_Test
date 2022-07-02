using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Command.Tickets;

public class BuyTicketCommand : ICommand
{
	public BuyTicketCommand(Id<Movie> movieId, DateTime seanceDate, string email, int quantity)
	{
		MovieId = movieId;
		SeanceDate = seanceDate;
		Email = email;
		Quantity = quantity;
	}

	public Id<Movie> MovieId { get; set; }
	public DateTime SeanceDate { get; set; }
	public string Email { get; set; }
	public int Quantity { get; set; }
}