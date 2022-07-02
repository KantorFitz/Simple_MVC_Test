using System;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Projekt.Domain.Command.Seances;
using SzkolenieTechniczne.Projekt.Domain.Mediator;
using SzkolenieTechniczne.Projekt.Domain.Query.GetMovieQuery;

namespace SzkolenieTechniczne.Projekt.UI.Controllers;

public class SeanceController : Controller
{
	private readonly IMediator _mediator;

	public SeanceController(IMediator mediator)
	{
		_mediator = mediator;
	}

	public IActionResult Index(Guid id)
	{
		var movie = _mediator.Query(new GetMovieQuery(id));

		return View(movie);
	}

	public IActionResult Add(Guid movieId)
	{
		var command = new RegisterSeanceCommand
		{
			MovieId = movieId,
			SeanceDate = DateTime.Now
		};

		return View(command);
	}

	[HttpPost]
	public IActionResult Add(Guid movieId, RegisterSeanceCommand command)
	{
		var result = _mediator.Command(command);
		if (result.IsFailure)
		{
			ModelState.PopulateValidation(result.Errors);
			return View(command);
		}

		return RedirectToAction("Index", new { id = movieId });
	}
}