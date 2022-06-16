using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Query.DTO;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Query.GetSeatsInUse;

public class GetSeatsInUseQuery : IQuery<int>
{
	public Id<Movie> MovieId { get; set; }
	public DateTime SeanceDate { get; set; }

	public GetSeatsInUseQuery(Id<Movie> movieId, DateTime seanceDate)
	{
		MovieId = movieId;
		SeanceDate = seanceDate;
	}
}