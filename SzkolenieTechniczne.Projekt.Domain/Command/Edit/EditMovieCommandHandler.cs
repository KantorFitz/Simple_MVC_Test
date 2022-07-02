using SzkolenieTechniczne.Projekt.Domain.Repository;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Command.Edit;

public class EditMovieCommandHandler : ICommandHandler<EditMovieCommand>
{
	private readonly IUnitOfWork _unitOfWork;

	public EditMovieCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public Result Handle(EditMovieCommand command)
	{
		var validationresult = new EditMovieCommandValidator().Validate(command);

		if (!validationresult.IsValid)
		{
			return Result.Fail(validationresult);
		}

		var movie = _unitOfWork.MoviesRepository.GetById(new Id<Entities.Movie>(command.Id));
		if (movie == null)
		{
			return Result.Fail("Movie does not exist");
		}

		movie.SetName(command.Name);
		movie.SetYear(command.Year);
		movie.SetSeanceTime(command.ScenarioTime);

		_unitOfWork.MoviesRepository.Update(movie);
		_unitOfWork.Commit();

		return Result.Ok();
	}
}