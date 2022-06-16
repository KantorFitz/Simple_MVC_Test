using SzkolenieTechniczne.Projekt.Domain.Query.DTO;
using SzkolenieTechniczne.Projekt.Domain.Repository;

namespace SzkolenieTechniczne.Projekt.Domain.Query.GetAllMoviesQuery;

public class GetAllMovieQueryHandler : IQueryHandler<GetAllMovieQuery, List<MovieDto>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllMovieQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public List<MovieDto> Handler(GetAllMovieQuery query)
	{
		var movies = _unitOfWork.MoviesRepository.GetAll();
		return movies.Select(item => new MovieDto(item.Name, item.Id)).ToList();
	}
}