using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MovieApp.Dtos;
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
        public IHttpActionResult GetCustomers()
        {
            var customersDto = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            if(customersDto == null)
                return NotFound();

            return Ok(customersDto);
        }

        // GET: /api/Customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var customerInDb = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerInDb));
        }

        // POST: /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;

                // URI: Unified Resource Identifier
                return Created(new Uri($"{Request.RequestUri}{customer.Id}"), customerDto);
            };

            return BadRequest();
        }

        // PUT: /api/Customers/id
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = _context.Customers
                    .Include(c => c.MembershipType)
                    .SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                    return NotFound();

                Mapper.Map(customerDto, customerInDb);

                _context.SaveChanges();

                return Ok(customerDto);
            };

            return BadRequest();
        }

        // DELETE: /api/Customers/id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c =>c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok(Mapper.Map<Customer, CustomerDto>(customerInDb));
        }
    }
}
