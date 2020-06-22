using FluentValidation;
using Forma1.Data.Models;
using System;

namespace Forma1.Web.Validators
{
	public class TeamValidator : AbstractValidator<Team>
	{
		private int FirstDate = 1940;

		public TeamValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).Length(0, 20);
			RuleFor(x => x.NumberOfWonWorldChampionship).GreaterThanOrEqualTo(0);
			RuleFor(x => x.YearOfFoundation).InclusiveBetween(FirstDate, DateTime.Now.Year);
		}
	}
}
