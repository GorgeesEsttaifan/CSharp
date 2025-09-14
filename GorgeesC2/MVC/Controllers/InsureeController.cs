using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            // Validate form inputs against model rules
            if (!ModelState.IsValid)
            {
                // If validation fails, return the form with error messages
                return View(insuree);
            }

            // Start with the base insurance rate
            decimal baseQuote = 50.00m;

            // Calculate the applicant's age based on their date of birth
            int age = DateTime.Today.Year - insuree.DateOfBirth.Year;
            if (insuree.DateOfBirth > DateTime.Today.AddYears(-age)) age--;

            // Adjust quote based on age category
            if (age <= 18)
            {
                baseQuote += 100m;
            }
            else if (age <= 25)
            {
                baseQuote += 50m;
            }
            else
            {
                baseQuote += 25m;
            }

            // Add extra charge for cars older than 2000 or newer than 2015
            if (insuree.CarYear < 2000 || insuree.CarYear > 2015)
            {
                baseQuote += 25m;
            }

            // Clean up car make and model input for consistent evaluation
            string make = insuree.CarMake?.Trim().ToLower() ?? "";
            string model = insuree.CarModel?.Trim().ToLower() ?? "";

            // Increase quote for certain luxury or performance vehicles
            if (make == "BMW")
            {
                baseQuote += 25m;

                if (model == "m3")
                {
                    baseQuote += 25m;
                }
            }

            // Add $10 per speeding ticket to the quote
            baseQuote += insuree.SpeedingTickets * 10m;

            // If the applicant has a DUI, increase the quote by 25%
            if (insuree.DUI)
            {
                baseQuote *= 1.25m;
            }

            // If full coverage is selected, apply a 50% increase
            if (insuree.CoverageType)
            {
                baseQuote *= 1.50m;
            }

            // Assign the calculated quote to the insuree object
            insuree.Quote = baseQuote;

            // Add the insuree to the database and persist changes
            db.Insurees.Add(insuree);
            db.SaveChanges();

            // Redirect back to the Index view after successful creation
            return RedirectToAction("Index");
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
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
