using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SzkolenieTechniczne.Projekt.Domain;

namespace SzkolenieTechniczne.Projekt.UI;

public static class AspNetExtensions
{
	public static void PopulateValidation(this ModelStateDictionary modelState, IEnumerable<Result.Error> errors)
	{
		foreach (var error in errors) modelState.AddModelError(error.PropertyName, error.Message);
	}
}