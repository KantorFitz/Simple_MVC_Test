using SzkolenieTechniczne.Projekt.Domain.Query.DTO;
using SzkolenieTechniczne.Projekt.Domain.Repository;

namespace SzkolenieTechniczne.Projekt.Domain.Query.GetMovieQuery;

public class GetMovieQueryHandler : IQueryHandler<GetMovieQuery, MovieDetailsDTO>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetMovieQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public MovieDetailsDTO Handler(GetMovieQuery query)
	{
		var movie = _unitOfWork.MoviesRepository.GetById(query.MovieId);
		if (movie==null)
		{
			throw new NullReferenceException("Given movie does not exist.");
		}

		var seances = new List<SeanceDTO>();

		if (movie.Seances is not null)
		{
			seances = movie.Seances.Select(x => new SeanceDTO(x.Id.Value, x.Date)).ToList();
		}

		return new MovieDetailsDTO(movie.Id.Value, movie.Name, movie.Year, movie.SeanceTime, seances);
	}
}