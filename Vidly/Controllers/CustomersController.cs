using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        #region ApplicationDbContext
        //We need DbContext to access db. private by convention
        private ApplicationDbContext _context;

        public CustomersController()
        {
            //needs to be initialized in the constructor
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //ApplicationDbContext this is a disposable object. override Dispose from the base Controller class
            _context.Dispose();
        }
        #endregion


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        
        //public ActionResult Save(CustomerFormViewModel viewModel) //Model Binding: mvc framework automat. maps request data to this obj
        [HttpPost]
        [ValidateAntiForgeryToken] //++ Helper method on View 
        public ActionResult Save(Customer customer) //mvc framwrk can map the req data (CustomerFormViewModel) to Customer (all objs are prefixed with customer.) 
        {
            //ModelState grants access to validation data
            if (!ModelState.IsValid) //Check if model is valid
            {
                //To add validation - 3 steps:
                //1. Add Data Annotations ~ attributes ~ to model props
                //2. Use ModelState to change flow of the program when needed
                //3. Add validation messages (view)

                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm" , viewModel);
            }

            if (customer.Id == 0) //new customer - create
            {
                _context.Customers.Add(customer);
            }
            else //existing customer - update
            {
                var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);

                //TryUpdateModel(...) may lead to security issues

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            _context.SaveChanges(); //atomic
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index()
        {
            //Include: eager loading. allow customer related objects to be sent to the view
            //with _context.Customers.ToList() executes immediatly
            List<Customer> customers = _context.Customers.Include(x => x.MembershipType).ToList(); //otherwise ~ defered execution. only when the obj is iterated.

            return View(customers);
        }

        [Route("customers/detail/{id:min(0)}")]
        public ActionResult Detail(int id)
        {
            var customers = _context.Customers.SingleOrDefault(x => x.Id == id); //executes immediatly ~ SingleOrDefault
            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            if (customer == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel); //without "New" MVC will look for a view called "Edit"
        }

        //// GET: Customers
        //public ActionResult Index()
        //{
        //    List<Customer> customers = GetAllCustomers();
        //    return View(customers);
        //}

        //[Route("customers/detail/{id:min(0)}")]
        //public ActionResult Detail(int id)
        //{
        //    Customer customers = GetCustomerById(id);
        //    return View(customers);
        //}



        //public List<Customer> GetAllCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id = 1, Name = "Fonseca Galhão"},
        //        new Customer{Id = 1, Name = "Sancho Paulo"}
        //    };
        //}
        //public Customer GetCustomerById(int id)
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id = 1, Name = "Fonseca Galhão"},
        //        new Customer{Id = 1, Name = "Sancho Paulo"}
        //    }.First(x => x.Id == id);
        //}
    }
}