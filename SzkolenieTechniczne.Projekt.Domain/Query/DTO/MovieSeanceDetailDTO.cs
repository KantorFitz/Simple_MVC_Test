using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Query.DTO;

public class MovieSeanceDetailDTO
{
	public Id<Movie> MovieId { get; set; }
	public Id<Seance> SeanceId { get; set; }
	public string MovieName { get; set; }
	public DateTime SeanceDate { get; set; }

	public MovieSeanceDetailDTO(Movie movie, Seance seance)
	{
		MovieId = movie.Id;
		SeanceId = seance.Id;
		MovieName = movie.Name;
		SeanceDate = seance.Date;
	}
}