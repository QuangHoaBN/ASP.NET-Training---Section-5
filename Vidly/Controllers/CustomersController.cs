using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            //Tạo viewmodel để chứa các thành phần để hiển thị
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer=new Customer(),
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                    
                };
                return View("New",viewModel);
            }
            if (customer.Id == 0)
            {
                //Chưa tồn tại thì Create
                _context.Customers.Add(customer);
            }
            else
            {
                //Đã tồn tại thì Update
                var cusInDb = _context.Customers.Single(c => c.Id == customer.Id);
                cusInDb.Name = customer.Name;
                cusInDb.Birthday = customer.Birthday;
                cusInDb.MembershipTypeId = customer.MembershipTypeId;
                cusInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        // GET: Customes/Index
        public ViewResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var cus = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (cus == null) return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = cus,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New",viewModel);
        }
    }
}