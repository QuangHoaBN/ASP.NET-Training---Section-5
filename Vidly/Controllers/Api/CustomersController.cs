using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //Get /api/customers/1
        public IHttpActionResult GetCustomers(int id)
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
        public void UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cusIndB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cusIndB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto,cusIndB);
            _context.SaveChanges();
        }
        [HttpDelete]
        //DELETE /api/customers/1
        public void DeleteCustomer(int id)
        {
            var cusInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (cusInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(cusInDb);
            _context.SaveChanges();
        }
    }
}
