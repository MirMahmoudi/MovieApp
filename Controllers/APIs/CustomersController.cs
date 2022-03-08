using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieApp.Models;

namespace MovieApp.Controllers.APIs
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .ToList();

            if(customers == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customers;
        }

        // GET: /api/Customers/id
        public Customer GetCustomer(int id)
        {
            var customerInDb = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customerInDb;
        }

        // POST: /api/Customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return customer;
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT: /api/Customers/id
        [HttpPut]
        public Customer UpdateCustomer(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedNewsLetter = customer.IsSubscribedNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

                _context.SaveChanges();

                return customerInDb;
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // DELETE: /api/Customers/id
        [HttpDelete]
        public Customer DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c =>c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return customerInDb;
        }
    }
}
