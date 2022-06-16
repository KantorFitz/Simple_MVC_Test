using FluentAssertions;
using NSubstitute;
using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Query.GetMovieQuery;
using SzkolenieTechniczne.Projekt.Domain.Repository;
using Xunit;

namespace SzkolenieTechniczne3.Projekt.Test.Unit.Tests;

public class GetAllMoviesQueryTest
{
	[Fact]
	public void GetMovie_WhenItsExist_ShouldSuccess()
	{
		using var sut = new SystemUnderTests();
		var movie = sut.CreateMovie("Harry Potter", 2001, 150);
		var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

		unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id).Returns(movie);

		var query = new GetMovieQuery(movie.Id.Value);
		var queryHandler = new GetMovieQueryHandler(unitOfWorkSubstitute);
		var moviesQuery = queryHandler.Handler(query);

		moviesQuery.Name.Should().Be("Harry Potter");
	}

	[Fact]
	public void GetMovie_WhenNoSeance_ShouldSuccess()
	{
		using var sut = new SystemUnderTests();
		var movie = new Movie("Harry Potter", 2001, 150);
		var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

		unitOfWorkSubstitute.MoviesRepository.GetById(movie.Id)
			.Returns(movie);

		var query = new GetMovieQuery(movie.Id.Value);
		var queryHandler = new GetMovieQueryHandler(unitOfWorkSubstitute);
		var moviesQuery = queryHandler.Handler(query);

		moviesQuery.Seances.Count.Should().Be(0);
	}
}