using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;
using System.Data.Entity;

namespace MovieApp.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /Customers
        public ActionResult Index()
        {
            var customers = new CustomersViewModel
            {
                Customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
            };

            return View(customers);
        }

        // GET: /Customers/Details/id
        public ActionResult Details(int id)
        {
            var customersInDb = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if(customersInDb == null)
                return HttpNotFound();

            var customerViewModel = new CustomersViewModel { Customer = customersInDb };

            return View(customerViewModel);
        }

        // GET: /Customers/New
        public ActionResult New()
        {
            var customerFormViewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes
            };

            return View("CustomerForm", customerFormViewModel);
        }

        //POST: /Customers/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(CustomerFormViewModel cutomer)
        {
            if (ModelState.IsValid)
            {
                var CutomerInDb = new Customer
                {
                    Name= cutomer.Name,
                    MembershipTypeId = cutomer.MembershipTypeId,
                    Birthdate = cutomer.Birthdate,
                    IsSubscribedNewsLetter = cutomer.IsSubscribedNewsLetter
                };

                _context.Customers.Add(CutomerInDb);
                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            };

            var customerFormViewModel = new CustomerFormViewModel(cutomer)
            {
                MembershipTypes= _context.MembershipTypes
            };

            return View("CustomerForm", customerFormViewModel);
        }

        // GET: /Customers/Edit/id
        public ActionResult Edit(int id)
        {
            var customerInDb = _context.Customers
                .FirstOrDefault(c => c.Id == id);

            if(customerInDb == null)
                return HttpNotFound();

            var customer = new CustomerFormViewModel(customerInDb)
            {
                MembershipTypes = _context.MembershipTypes
            };

            return View("CustomerForm", customer);
        }

        // POST: /Customers/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerFormViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                if (customer == null)
                    return HttpNotFound();

                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedNewsLetter = customer.IsSubscribedNewsLetter;

                _context.SaveChanges();

                return RedirectToAction("Index", "Customers");
            };

            var customerFormViewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes=_context.MembershipTypes
            };

            return View("CustomerForm", customerFormViewModel);
        }
    }
}