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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customersDto = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            if(customersDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customersDto;
        }

        // GET: /api/Customers/id
        public CustomerDto GetCustomer(int id)
        {
            var customerInDb = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDto>(customerInDb);
        }

        // POST: /api/Customers
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();

                customerDto.Id = customer.Id;
                return customerDto;
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT: /api/Customers/id
        [HttpPut]
        public CustomerDto UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                var customerInDb = _context.Customers
                    .Include(c => c.MembershipType)
                    .SingleOrDefault(c => c.Id == id);

                if (customerInDb == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                Mapper.Map(customerDto, customerInDb);

                _context.SaveChanges();

                return customerDto;
            };

            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // DELETE: /api/Customers/id
        [HttpDelete]
        public CustomerDto DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c =>c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Mapper.Map<Customer, CustomerDto>(customerInDb);
        }
    }
}
