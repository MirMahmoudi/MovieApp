using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customer1 = new Customer
            {
                Name = "Joe Smith"
            };
            
            var customer2 = new Customer
            {
                Name = "John Doe"
            };

            var customersList = new List<Customer>();
            //customersList.Add(customer1);
            //customersList.Add(customer2);

            var customers = new CustomersViewModel
            {
                Customers = customersList
            };

            return View(customers);
        }
    }
}