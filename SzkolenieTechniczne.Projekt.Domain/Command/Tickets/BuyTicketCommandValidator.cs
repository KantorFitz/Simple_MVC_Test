using FluentValidation;

namespace SzkolenieTechniczne.Projekt.Domain.Command.Tickets;

public class BuyTicketCommandValidator : AbstractValidator<BuyTicketCommand>
{
	public BuyTicketCommandValidator()
	{
		RuleFor(x => x.MovieId).NotEmpty();
		RuleFor(x => x.SeanceDate).NotEmpty();
		RuleFor(x => x.Email).NotEmpty();
		RuleFor(x => x.Quantity).GreaterThan(0);
	}
}