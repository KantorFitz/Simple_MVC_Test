using System;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Projekt.Domain.Command.Add;
using SzkolenieTechniczne.Projekt.Domain.Command.Delete;
using SzkolenieTechniczne.Projekt.Domain.Command.Edit;
using SzkolenieTechniczne.Projekt.Domain.Mediator;
using SzkolenieTechniczne.Projekt.Domain.Query.GetAllMoviesQuery;
using SzkolenieTechniczne.Projekt.Domain.Query.GetMovieQuery;

namespace SzkolenieTechniczne.Projekt.UI.Controllers;

public class MovieController : Controller
{
	private readonly IMediator _mediator;

	public MovieController(IMediator mediator)
	{
		_mediator = mediator;
	}

	// GET
	public IActionResult Index()
	{
		var movies = _mediator.Query(new GetAllMovieQuery());

		return View(movies);
	}

	public IActionResult Add()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Add(AddMovieCommand command)
	{
		var result = _mediator.Command(command);
		if (result.IsFailure)
		{
			ModelState.PopulateValidation(result.Errors);
			return View(command);
		}
		
		return RedirectToAction("Index");
	}

	public IActionResult Edit(Guid id)
	{
		var movie = _mediator.Query(new GetMovieQuery(id));
		var model = new EditMovieCommand
		{
			Id = movie.Id,
			Name = movie.Name,
			Year = movie.Year,
			ScenarioTime = movie.SeanceTime
		};

		return View(model);
	}

	[HttpPost]
	public IActionResult Edit(EditMovieCommand command)
	{
		var result = _mediator.Command(command);
		if (result.IsFailure)
			return View(command);

		return RedirectToAction("Index");
	}

	[HttpPost]
	public IActionResult Delete(Guid id)
	{
		var result = _mediator.Command(new DeleteMovieCommand(id));
		if (result.IsSuccess == false) ViewData["Error"] = result.Message;

		return RedirectToAction("Index");
	}
}