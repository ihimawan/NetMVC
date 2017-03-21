using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
		//GET: Movies/Random
        public ActionResult Random()
        {
			var movie = new Movie { Name = "Shrek" };
			var customers = new List<Customer> { 
				new Customer{ Name = "Customer 1"},
				new Customer{ Name = "Customer 2"}
			};

			var viewModel = new RandomMovieViewModel{
				Movie = movie,
				Customers = customers
			};

			//return Content("Hey"); //will return just text
			//return HttpNotFound(); //will return 404 page
			//return new EmptyResult(); //will return empty page
			//return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" }); 
			//redirect to an action 'Index' in controller 'Home'
			//the arguments in the anonymous object will appear as query string.

			//return View(movie); //this is actually a method that does 'new ViewResult()'

			//other ways to return view. This is the first way:
			//ViewData["Movie"] = movie; //ViewData is a dictionary.

			//this is the second way
			//ViewBag.Movie = movie; //the property is added to ViewBag at runtime.

			return View(viewModel); //If you use either viewdata/viewbag, you don't need to pass model as parameter here.
			//!!HOWEVER!! Do NOT use Viewdata or viewbag lol
        }

		//GET: Movies (Movies/Index more precisely)
		/*
		public ActionResult Index()
		{
			return View();
		}
		*/

		//This will accept either /movies/edit/1 or /movies/edit?id=1
		// the /1 is based on how you set your router.
		// the ?id=1 is based on how you name your parameter. If it is int movieId, then only ?movieId=1 will work
		public ActionResult Edit(int id)
		{
			return Content("id = " + id);
		}

		//the '?' makes it nullable
		public ActionResult Index(int? pageIndex, string sortBy)
		{
			if (!pageIndex.HasValue)
			{
				pageIndex = 1;
			}

			if (String.IsNullOrWhiteSpace(sortBy))
			{
				sortBy = "Name";
			}

			return Content(String.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
		}

		//using attributes are more powerful, especially if you want to use constraints.
		[Route("movies/released/{year:regex(\\d{4})}/{month:range(1, 12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + " " + month);
		}
    }
}
