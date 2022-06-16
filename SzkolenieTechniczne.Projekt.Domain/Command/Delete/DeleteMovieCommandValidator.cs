using FluentValidation;

namespace SzkolenieTechniczne.Projekt.Domain.Command.Delete;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Provided Id id empty");
    }
}