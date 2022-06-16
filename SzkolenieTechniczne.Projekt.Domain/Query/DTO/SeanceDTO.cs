namespace SzkolenieTechniczne.Projekt.Domain.Query.DTO;

public class SeanceDTO
{
	public Guid Id { get; set; }
	public DateTime? Date { get; set; }

	public SeanceDTO(Guid id, DateTime? date)
	{
		Id = id;
		Date = date;
	}
}