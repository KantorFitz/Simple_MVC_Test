using System;
using System.Collections.Generic;
using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne3.Projekt.Test.Unit.ModelProxies;

public class SeanceProxy : Seance
{
	public SeanceProxy(DateTime date, Id<Movie> movieId) : base(date, movieId)
	{
		Tickets = new List<Ticket>();
	}
}