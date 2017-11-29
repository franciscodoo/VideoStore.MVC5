using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = GetAllCustomers();
            return View(customers);
        }

        [Route("customers/detail/{id:min(0)}")]
        public ActionResult Detail(int id)
        {
            Customer customers = GetCustomerById(id);
            return View(customers);
        }



        public List<Customer> GetAllCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id = 1, Name = "Fonseca Galhão"},
                new Customer{Id = 1, Name = "Sancho Paulo"}
            };
        }
        public Customer GetCustomerById(int id)
        {
            return new List<Customer>
            {
                new Customer{Id = 1, Name = "Fonseca Galhão"},
                new Customer{Id = 1, Name = "Sancho Paulo"}
            }.First(x => x.Id == id);
        }

    }
}