using System;
using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class RandomMovieViewModel
	{
		//ViewModel includes data that is specific for that View.
		public RandomMovieViewModel()
		{

		}

		public Movie Movie
		{
			get;
			set;
		}

		public List<Customer> Customers
		{
			get;
			set;
		}

	}
}
