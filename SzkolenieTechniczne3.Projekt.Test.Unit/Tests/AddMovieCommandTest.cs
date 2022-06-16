using FluentAssertions;
using NSubstitute;
using SzkolenieTechniczne.Projekt.Domain.Command.Add;
using SzkolenieTechniczne.Projekt.Domain.Repository;
using Xunit;

namespace SzkolenieTechniczne3.Projekt.Test.Unit.Tests;

public class AddMovieCommandTest
{
	[Fact]
	public void AddMovie_WhenExist_ShouldFail()
	{
		using var sut = new SystemUnderTests();
		var command = new AddMovieCommand
		{
			Name = "Harry Portier",
			Year = 20001,
			SeanceTime = 150
		};
		var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

		unitOfWorkSubstitute.MoviesRepository.IsMovieExist(command.Name, command.Year).Returns(true);

		var handler = new AddMovieCommandHandler(unitOfWorkSubstitute);
		var result = handler.Handle(command);

		result.IsFailure.Should().Be(true);
	}

	[Fact]
	public void AddMovie_WhenItIsPossible_ShouldSuccess()
	{
		using var sut = new SystemUnderTests();
		var command = new AddMovieCommand
		{
			Name = "Harry Portier",
			Year = 20001,
			SeanceTime = 150
		};
		var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

		var handler = new AddMovieCommandHandler(unitOfWorkSubstitute);
		var result = handler.Handle(command);

		result.IsSuccess.Should().Be(true);
	}
}