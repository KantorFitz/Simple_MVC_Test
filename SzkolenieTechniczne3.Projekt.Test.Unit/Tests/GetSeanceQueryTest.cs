using System.Linq;
using FluentAssertions;
using NSubstitute;
using SzkolenieTechniczne.Projekt.Domain.Query.GetSeanceQuery;
using SzkolenieTechniczne.Projekt.Domain.Repository;
using Xunit;

namespace SzkolenieTechniczne3.Projekt.Test.Unit.Tests;

public class GetSeanceQueryTest
{
	[Fact]
	public void GetSeance_WhenItsExist_ShouldSuccess()
	{
		using var sut = new SystemUnderTests();
		var movie = sut.CreateMovie("Harry Potter", 2001, 150);
		var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

		unitOfWorkSubstitute.MoviesRepository.GetSeanceDetails(movie.Id)
			.Returns(movie);

		var query = new GetSeanceQuery(movie.Id.Value, movie.Seances.First().Id.Value);
		var queryHandler = new GetSeanceQueryHandler(unitOfWorkSubstitute);
		var seanceQuery = queryHandler.Handler(query);

		seanceQuery.MovieName.Should().Be("Harry Potter");
	}
}