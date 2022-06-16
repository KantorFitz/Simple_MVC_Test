using FluentValidation;

namespace SzkolenieTechniczne.Projekt.Domain.Command.Edit
{
    public class EditMovieCommandValidator : AbstractValidator<EditMovieCommand>
    {
        public EditMovieCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Year).InclusiveBetween(1900, 2040);
            RuleFor(x => x.ScenarioTime).InclusiveBetween(30, 300);
        }
    }
} 