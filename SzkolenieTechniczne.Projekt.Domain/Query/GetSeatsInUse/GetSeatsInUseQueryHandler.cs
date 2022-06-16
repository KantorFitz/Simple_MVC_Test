using SzkolenieTechniczne.Projekt.Domain.Query.DTO;
using SzkolenieTechniczne.Projekt.Domain.Repository;

namespace SzkolenieTechniczne.Projekt.Domain.Query.GetSeatsInUse;

public class GetSeatsInUseQueryHandler : IQueryHandler<GetSeatsInUseQuery, int>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetSeatsInUseQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	
	public int Handler(GetSeatsInUseQuery query)
	{
		var movie = _unitOfWork.MoviesRepository.GetById(query.MovieId);
		var seance = movie.GetSeanceByDateAndRoomId(query.SeanceDate);
		var purchasesTickets = seance.GetAllSeanceTicket();

		return purchasesTickets.Sum(x => x.PeopleCount);
	}
}