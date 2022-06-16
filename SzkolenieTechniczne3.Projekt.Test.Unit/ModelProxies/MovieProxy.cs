using System.Collections.Generic;
using SzkolenieTechniczne.Projekt.Domain.Entities;

namespace SzkolenieTechniczne3.Projekt.Test.Unit.ModelProxies;

public class MovieProxy : Movie
{
	public MovieProxy(string name, int year, int seanceTime) : base(name, year, seanceTime)
	{
		Seances = new List<Seance>();
	}
}