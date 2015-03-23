using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomIDTest.Models;
using System.Data.Entity.Infrastructure;

namespace CustomIDTest.Controllers
{
    public class EmployeesController : Controller
    {
        private EmpContext db = new EmpContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FirstName,LastName,Reference,ManualRefrence")] Employee employee)
        {
          
            //initialization

            // take the reference request
            string ReferenceBuff = ""; 

            try
            {
                ReferenceBuff = Request["Reference"].ToString();
            }
            catch (NullReferenceException) 
            {
                ReferenceBuff = "";
            }
            //initialize employee instance to null 
            Employee empRef = null ;
            //initialize the current date to use current year
            DateTime date = DateTime.Now;

            //initialize string for manual reference
            string ManualRef = "" ;

            if (ReferenceBuff == "")
            {

                empRef = null ;
            }
            else 
            {
                try
                {
                    empRef = db.Employees.First(x => x.Reference == ReferenceBuff);
                }
                catch (InvalidOperationException)
                {
                    empRef = null;
                }
               
                if (empRef != null)
                {
                    return RedirectToAction("ErrorPage");
                }
                else 
                {
                    ManualRef = "FSR-WL/" + ReferenceBuff + "/" + date.Year;
                }

            }

                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Employees.Add(employee);
                        db.SaveChanges();
                        if (ReferenceBuff == "")
                        {
                            var refer = addRef(employee);
                            employee.Reference = refer;
                        }
                        else
                        {
                            employee.Reference = ManualRef;
                        }
                        db.SaveChanges();
                    }
                    catch (DbUpdateException)
                    {
                        db.Entry(employee).State = EntityState.Deleted;
                        db.SaveChanges();
                        return RedirectToAction("ErrorPage");
                    }
                    
                    return RedirectToAction("Index");

                }


                //db.SaveChanges();
                return View(employee);

        }

        public string addRef(Employee emp)
        {
            DateTime date = DateTime.Now;
            //string id_buff = Convert.ToString(this.EmployeeID) ;
            return "FSR-WL/" + emp.EmployeeID + "/" + date.Year;
        }


        public ActionResult ErrorPage()
        {

            return View();
        }


        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,LastName,Reference")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
