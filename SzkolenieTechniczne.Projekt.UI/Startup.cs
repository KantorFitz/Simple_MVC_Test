using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SzkolenieTechniczne.Projekt.Cimena.Infrastructure;
using SzkolenieTechniczne.Projekt.Cimena.Infrastructure.Repositories;
using SzkolenieTechniczne.Projekt.Domain.Repository;

namespace SzkolenieTechniczne.Projekt.UI
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; }
		public ILifetimeScope AutofacContainer { get; set; }

		public Startup(IWebHostEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"AppSettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		public void ConfigureContainer(ContainerBuilder containerBuilder)
		{
			containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
			containerBuilder.RegisterType<MoviesRepository>().As<IMoviesRepository>().InstancePerLifetimeScope();
			containerBuilder.ConfigureMediator();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			var connectionString = Configuration.GetConnectionString("CinemaTicketDatabase");

			services.AddDbContext<CinemaTicketDbContext>(opt =>
			{
				opt.UseSqlServer(connectionString);
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			// app.UseHangfireDashboard(); // /hangfire

			AutofacContainer = app.ApplicationServices.GetAutofacRoot();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Movie}/{action=Index}/{id?}");
			});
		}
	}
}