using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Query.DTO;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Query.GetSeanceQuery;

public class GetSeanceQuery : IQuery<MovieSeanceDetailDTO>
{
	public Id<Movie> MovieId { get; }
	public Id<Seance> SeanceId { get; }

	public GetSeanceQuery(Guid movieId, Guid seanceId)
	{
		MovieId = new Id<Movie>(movieId);
		SeanceId = new Id<Seance>(seanceId);
	}
}