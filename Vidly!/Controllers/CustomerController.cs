using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly_.Models;

namespace Vidly_.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
        public ActionResult New()
        {
            var membershiptypes = _context.MemberShipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                customer = new Customer(),
                MemberShipTypes=membershiptypes
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer1 = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer1 == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel 
            {
                customer=customer1,
                MemberShipTypes=_context.MemberShipTypes.ToList()
            };
            return View("New",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    customer = customer,
                    MemberShipTypes=_context.MemberShipTypes.ToList()
                };
                return View("New",viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
    }
}
