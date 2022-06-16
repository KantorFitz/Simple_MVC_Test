using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Query.DTO;

public class MovieDto
{
	public string Name { get; set; }
	public Id<Movie> Id { get; set; }

	public MovieDto(string name, Id<Movie> id)
	{
		Name = name;
		Id = id;
	}
}