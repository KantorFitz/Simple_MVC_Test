using System;
using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne3.Projekt.Test.Unit.ModelProxies;

namespace SzkolenieTechniczne3.Projekt.Test.Unit
{
	public class SystemUnderTests : IDisposable
	{
		public void Dispose()
		{
		}

		public Movie CreateMovie(string name, int year, int seanceTime)
		{
			var movie = new MovieProxy(name, year, seanceTime);
			movie.Seances.Add(new SeanceProxy(DateTime.Parse("2022-10-05T10:12:12"), movie.Id));
			movie.Seances.Add(new SeanceProxy(DateTime.Parse("2022-10-06T10:12:12"), movie.Id));
			return movie;
		}
	}
}