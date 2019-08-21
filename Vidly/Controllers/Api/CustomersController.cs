using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/customers
        public IHttpActionResult GetCustomersDtos(string query=null)
        {
            var customerQuery = _context.Customers
                .Include(c => c.MembershipType);
            if (!string.IsNullOrWhiteSpace(query))
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));
            var cusDtos = customerQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(cusDtos);
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomersDtos(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customer.Id = customerDto.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }
        
        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cusIndB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cusIndB == null)
                return NotFound();

            Mapper.Map(customerDto,cusIndB);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        //DELETE /api/customers/1
        public IHttpActionResult DeleteCustomer(int id)
        {
            var cusInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (cusInDb == null)
                return NotFound();
            _context.Customers.Remove(cusInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
