namespace SzkolenieTechniczne.Projekt.Domain.Command;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Result Handle(TCommand command);
}