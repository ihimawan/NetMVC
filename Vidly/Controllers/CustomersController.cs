using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{



    public class CustomersController : Controller
    {
		public List<Customer> CustomerList { get; private set; }

		public CustomersController()
		{	

			CustomerList = new List<Customer>
			{
				new Customer {Name = "Spongebob Squarepants"},
				new Customer {Name = "Patrick Star"}
			};

		}

		[Route("customers/details/{id:regex(\\d)}")]
		public ActionResult Details(int id)
		{
			return View(CustomerList[id]);
		}

		[Route("customers")]
        public ActionResult Index()
        {
			var modelView = new RandomMovieViewModel();
			modelView.Customers = CustomerList;

			return View (modelView);
        }



    }
}
