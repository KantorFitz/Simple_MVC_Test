using System;

namespace SzkolenieTechniczne.Projekt.UI.Models;

public class BuyTicketViewModel
{
	public Guid MovieId { get; set; }
	public Guid SeanceId { get; set; }
	public string MovieName { get; set; }
	public DateTime SeanceDate { get; set; }
	public string Email { get; set; }
	public int Quantity { get; set; }
}