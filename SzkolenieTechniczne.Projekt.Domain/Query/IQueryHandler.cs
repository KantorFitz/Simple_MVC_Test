namespace SzkolenieTechniczne.Projekt.Domain.Query;

public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
{
	TResult Handler(TQuery query);
}