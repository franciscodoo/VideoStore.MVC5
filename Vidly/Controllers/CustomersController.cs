using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
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


        public ActionResult Index()
        {
            //Include: eager loading. allow customer related objects to be sent to the view
            //with _context.Customers.ToList() executes immediatly
            List<Customer> customers = _context.Customers.Include(x => x.MembershipType).ToList(); //otherwise ~ defered execution. only when the obj is iterated.
            if (customers == null) 
                return HttpNotFound();

            return View(customers);
        }

        [Route("customers/detail/{id:min(0)}")]
        public ActionResult Detail(int id)
        {
            var customers = _context.Customers.SingleOrDefault(x => x.Id == id); //executes immediatly ~ SingleOrDefault
            return View(customers);
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