using SzkolenieTechniczne.Projekt.Domain.Command;
using SzkolenieTechniczne.Projekt.Domain.Query;

namespace SzkolenieTechniczne.Projekt.Domain.Mediator;

public interface IMediator
{
	Result Command<TCommand>(TCommand command) where TCommand : ICommand;
	TResponse Query<TResponse>(IQuery<TResponse> query);
	TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
}