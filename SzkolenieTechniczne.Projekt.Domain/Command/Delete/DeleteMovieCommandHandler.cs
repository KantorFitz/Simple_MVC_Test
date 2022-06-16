using SzkolenieTechniczne.Projekt.Domain.Repository;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.Domain.Command.Delete
{
	public class DeleteMovieCommandHandler : ICommandHandler<DeleteMovieCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteMovieCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Result Handle(DeleteMovieCommand command)
		{
			var validationReult = new DeleteMovieCommandValidator().Validate(command);
			if (!validationReult.IsValid)
			{
				return Result.Fail(validationReult);
			}

			var movie = _unitOfWork.MoviesRepository.GetById(new Id<Entities.Movie>(command.Id));
			if (movie == null)
			{
				return Result.Fail("Movie does not exist");
			}

			_unitOfWork.MoviesRepository.Remove(movie);
			_unitOfWork.Commit();

			return Result.Ok();
		}
	}
}