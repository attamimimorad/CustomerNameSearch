using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerNameSearch.Models;

namespace CustomerNameSearch.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerNameSearchContext db = new CustomerNameSearchContext();

        // GET: Customers
        public ActionResult Index(string searchString)
        {
            if (searchString != null)
            {
                var customers = db.Customers.ToList();
                var customersQ = new List<Customer>();
                var Thecustomers = new List<Customer>();



                Char delimiter = ' ';
                String[] substrings = searchString.Split(delimiter);


                for (int i = 0; i < substrings.Length; i++)
                {
                    customersQ = customers.Where(cust => (cust.FirstName + string.Empty + cust.MiddleName + string.Empty + cust.LastName + string.Empty + cust.Phone).Contains(substrings[i])).ToList();
                    if (customersQ.Count() > 0)
                    {
                        //for (int x = i + 1; x < substrings.Length; x++)
                        for (int x = 0; x < substrings.Length; x++)
                        {
                            Thecustomers = customersQ.Where(cust => (cust.FirstName + string.Empty + cust.MiddleName + string.Empty + cust.LastName + string.Empty + cust.Phone).Contains(substrings[x])).ToList();
                            if (Thecustomers.Count() == 0)
                            {
                                Thecustomers = customersQ;
                            }
                            else
                            {
                                customersQ = Thecustomers;
                            }
                        }


                    }
                    else
                    {
                        continue;

                    }

                }











                //for (int i = 1; i < substrings.Length; i++)
                //{


                //        //  customers.Concat(db.Customers.Where(cust => (cust.FirstName + string.Empty + cust.MiddleName + string.Empty + cust.LastName + string.Empty + cust.Phone).Contains(substrings[i])));
                //        if (customers.Count()>0)
                //        {
                //            customers.Union(db.Customers.Where(cust => (cust.FirstName + string.Empty + cust.MiddleName + string.Empty + cust.LastName + string.Empty + cust.Phone).Contains(substrings[i])));
                //        }
                //        else
                //        {
                //            customers = customers.Where(cust => (cust.FirstName + string.Empty + cust.MiddleName + string.Empty + cust.LastName + string.Empty + cust.Phone).Contains(substrings[0])).ToList();
                //        }




                //    }

                return View(Thecustomers);




            }
            else
            {
                return View(db.Customers.ToList());
            }
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,MiddleName,LastName,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,MiddleName,LastName,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
