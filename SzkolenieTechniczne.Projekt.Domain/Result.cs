using FluentValidation.Results;

namespace SzkolenieTechniczne.Projekt.Domain;

public class Result
{
    private Result(bool isSuccess, string message, IEnumerable<Error> errors)
    {
        IsSuccess = isSuccess;
        IsFailure = !isSuccess;
        Message = message;
        Errors = errors;
    }

    public string Message { get; }
    public bool IsFailure { get; }
    public bool IsSuccess { get; }
    public IEnumerable<Error> Errors { get; }

    public static Result Ok() => new Result(true, "", Enumerable.Empty<Error>());

    public static Result Fail(string message) => new Result(false, message, Enumerable.Empty<Error>());

    public static Result Fail(ValidationResult violationResult)
    {
        return new Result(false,
            string.Join(", ", violationResult.Errors.Select(x => x.ErrorMessage)),
            violationResult.Errors.Select(x => new Error(x.PropertyName, x.ErrorMessage)));
    }
    
    public class Error
    {
        public string PropertyName { get; }
        public string Message { get; }

        public Error(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
    }
}