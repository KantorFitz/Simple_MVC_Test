namespace SzkolenieTechniczne.Projekt.Domain;

public interface IDependencyResolver
{
	T? ResolveOrDefault<T>() where T : class;
}