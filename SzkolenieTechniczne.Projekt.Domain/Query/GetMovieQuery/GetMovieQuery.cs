using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Query.DTO;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Query.GetMovieQuery;

public class GetMovieQuery : IQuery<MovieDetailsDTO>
{
	public Id<Movie> MovieId { get; set; }


	public GetMovieQuery(Guid movieId)
	{
		MovieId = new Id<Movie>(movieId);
	}
}