using System;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Projekt.Domain.Command.Tickets;
using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Mediator;
using SzkolenieTechniczne.Projekt.Domain.Query.GetSeanceQuery;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;
using SzkolenieTechniczne.Projekt.UI.Models;

namespace SzkolenieTechniczne.Projekt.UI.Controllers;

public class TicketController : Controller
{
	private readonly IMediator _mediator;

	public TicketController(IMediator mediator)
	{
		_mediator = mediator;
	}

	public IActionResult Index(Guid movieId, Guid seanceId)
	{
		var seanceDetails = _mediator.Query(new GetSeanceQuery(movieId, seanceId));
		var model = new BuyTicketViewModel
		{
			MovieId = movieId,
			SeanceId = seanceId,
			SeanceDate = seanceDetails.SeanceDate,
			MovieName = seanceDetails.MovieName
		};

		return View(model);
	}

	[HttpPost]
	public IActionResult Index(Guid movieId, Guid seanceId, BuyTicketViewModel model)
	{
		var command = new BuyTicketCommand(new Id<Movie>(movieId), model.SeanceDate, model.Email, model.Quantity);
		var result = _mediator.Command(command);

		if (result.IsFailure)
		{
			ModelState.PopulateValidation(result.Errors);

			return View(model);
		}

		return RedirectToAction("Index", "Movie");
	}
}