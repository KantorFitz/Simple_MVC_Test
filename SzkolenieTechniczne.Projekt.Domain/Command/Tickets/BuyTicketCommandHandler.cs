using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Repository;

namespace SzkolenieTechniczne.Projekt.Domain.Command.Tickets;

public class BuyTicketCommandHandler : ICommandHandler<BuyTicketCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public BuyTicketCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public Result Handle(BuyTicketCommand command)
	{
		var validationResult = new BuyTicketCommandValidator().Validate(command);
		if (validationResult.IsValid == false)
			return Result.Fail(validationResult);

		var ticket = new Ticket(command.Email, command.Quantity);
		var movie = _unitOfWork.MoviesRepository.GetById(command.MovieId);
		var seance = movie.GetSeanceByDateAndRoomId(command.SeanceDate);

		seance.Add(ticket);
		_unitOfWork.Commit();
		
		return Result.Ok();
	}
}