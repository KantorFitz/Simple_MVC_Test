using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Repository;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Command.Seances;

public class RegisterSeanceCommandHandler : ICommandHandler<RegisterSeanceCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public RegisterSeanceCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
			
	public Result Handle(RegisterSeanceCommand command)
	{
		var validationResult = new RegisterSeanceCommandValidator().Validate(command);
		if (!validationResult.IsValid)
		{
			return Result.Fail(validationResult);
		}

		var movieId = new Id<Movie>(command.MovieId);
		var isSeanceExist = _unitOfWork.MoviesRepository.IsSeanceExist(command.SeanceDate);

		if (isSeanceExist)
		{
			return Result.Fail("Seance already exists");
			
		}

		var movie = _unitOfWork.MoviesRepository.GetById(movieId);
		if (movie == null)
		{
			return Result.Fail("This Movie does not exist");
		}

		var seance = new Seance(command.SeanceDate, movieId);

		movie.Seances.Add(seance);
		_unitOfWork.Commit();
		
		return Result.Ok();
	}
}