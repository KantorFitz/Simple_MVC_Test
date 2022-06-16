using SzkolenieTechniczne.Projekt.Domain.Query.DTO;
using SzkolenieTechniczne.Projekt.Domain.Repository;

namespace SzkolenieTechniczne.Projekt.Domain.Query.GetSeanceQuery;

public class GetSeanceQueryHandler : IQueryHandler<GetSeanceQuery, MovieSeanceDetailDTO>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetSeanceQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public MovieSeanceDetailDTO Handler(GetSeanceQuery query)
	{
		var movie = _unitOfWork.MoviesRepository.GetSeanceDetails(query.MovieId);
		if (movie == null)
		{
			throw new NullReferenceException("Movie not exists");
		}

		var seance = movie.Seances.SingleOrDefault(x => x.Id == query.SeanceId);
		if (seance  == null)
		{
			throw new NullReferenceException("Given seance does not exist");
		}

		return new MovieSeanceDetailDTO(movie, seance);
	}
}