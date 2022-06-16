namespace SzkolenieTechniczne.Projekt.Domain.Query.DTO;

public class MovieDetailsDTO
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public int Year { get; set; }
	public int SeanceTime { get; set; }
	public List<SeanceDTO> Seances { get; set; }

	public MovieDetailsDTO(Guid id, string name, int year, int seanceTime, List<SeanceDTO> seances)
	{
		Id = id;
		Name = name;
		Year = year;
		SeanceTime = seanceTime;
		Seances = seances;
	}
}