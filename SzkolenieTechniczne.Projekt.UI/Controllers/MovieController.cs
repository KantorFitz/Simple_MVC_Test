using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Projekt.Domain.Command.Add;
using SzkolenieTechniczne.Projekt.Domain.Command.Edit;
using SzkolenieTechniczne.Projekt.Domain.Entities;
using SzkolenieTechniczne.Projekt.Domain.Query.DTO;
using SzkolenieTechniczne.Projekt.Domain.ValueObject;

namespace SzkolenieTechniczne.Projekt.UI.Controllers;

public class MovieController : Controller
{
	// GET
	public IActionResult Index()
	{
		var movies = new List<MovieDto>()
		{
			new("Film 1", new Id<Movie>(Guid.NewGuid())),
			new("Film 2", new Id<Movie>(Guid.NewGuid())),
			new("Film 3", new Id<Movie>(Guid.NewGuid())),
		};

		return View(movies);
	}

	public IActionResult Add()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Add(AddMovieCommand command)
	{
		return RedirectToAction("Index");
	}

	public IActionResult Edit(Guid id)
	{
		var model = new EditMovieCommand();

		return View(model);
	}

	[HttpPost]
	public IActionResult Edit(EditMovieCommand command)
	{
		return RedirectToAction("Index");
	}

	[HttpPost]
	public IActionResult Delete(Guid id)
	{
		return RedirectToAction("Index");
	}
}