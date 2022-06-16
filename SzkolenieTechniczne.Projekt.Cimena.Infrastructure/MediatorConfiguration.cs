using Autofac;
using SzkolenieTechniczne.Projekt.Domain;
using SzkolenieTechniczne.Projekt.Domain.Command;
using SzkolenieTechniczne.Projekt.Domain.Command.Add;
using SzkolenieTechniczne.Projekt.Domain.Mediator;
using SzkolenieTechniczne.Projekt.Domain.Query;

namespace SzkolenieTechniczne.Projekt.Cimena.Infrastructure;

public static class MediatorConfiguration
{
	public static void ConfigureMediator(this ContainerBuilder containerBuilder)
	{
		containerBuilder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

		containerBuilder
			.Register(factory =>
			{
				var lifetimeScope = factory.Resolve<ILifetimeScope>();
				return new AutofacDependencyResolver(lifetimeScope.BeginLifetimeScope());
			})
			.As<IDependencyResolver>()
			.InstancePerLifetimeScope();

		var handlersAssembly = typeof(AddMovieCommandHandler).Assembly;
		containerBuilder
			.RegisterAssemblyTypes(handlersAssembly)
			.AsClosedTypesOf(typeof(ICommandHandler<>))
			.InstancePerLifetimeScope();

		containerBuilder
			.RegisterAssemblyTypes(handlersAssembly)
			.AsClosedTypesOf(typeof(IQueryHandler<,>))
			.InstancePerLifetimeScope();
	}
}