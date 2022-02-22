using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance2.Models;

namespace CarInsurance2.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Admin Page View
        public ActionResult Admin()
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
            if (ModelState.IsValid)
            {
                decimal baseQuote = 50.00m;

                //Age Checks
                DateTime now = DateTime.Now;
                DateTime insureeDOB = insuree.DateOfBirth;
                TimeSpan ageDaysRaw = now - insureeDOB;
                int ageDays = ageDaysRaw.Days;
                bool is18AndUnder = ageDays <= (18 * 365);//add 100
                bool isBetween19And25 = ageDays >= (19 * 365) && ageDays <= (25 * 365);//add 50
                bool isOver25 = ageDays > (25 * 365);//add 25

                //Car checks
                int carYear = insuree.CarYear;
                bool carBefore2000 = carYear < 2000;//add 25
                bool carAfter2015 = carYear > 2015;//add 25
                bool carIsPorsche = insuree.CarMake.ToLower() == "porsche";//add 25
                bool carIs911Carrera = insuree.CarModel.ToLower() == "911 carrera";//add 25

                //User checks
                int tickets = insuree.SpeedingTickets;
                bool hasTickets = tickets > 0;
                decimal priceModifierDUI = 1.25m;
                bool hasDUI = insuree.DUI == true;//add 25 percent to total
                decimal priceModifierFullCoverage = 1.5m;
                bool hasFullCoverage = insuree.CoverageType == true;//add 50 percent to total
                
                //Quote builder logic based on above checks 
                if (is18AndUnder) baseQuote += 100;
                if (isBetween19And25) baseQuote += 50;
                if (isOver25) baseQuote += 25;

                if (carBefore2000) baseQuote += 25;
                if (carAfter2015) baseQuote += 25;
                if (carIsPorsche) baseQuote += 25;
                if (carIs911Carrera) baseQuote += 25;

                if (hasTickets) baseQuote += tickets * 10;
                if (hasDUI) baseQuote = baseQuote * priceModifierDUI;
                if (hasFullCoverage) baseQuote = baseQuote * priceModifierFullCoverage;

                insuree.Quote = baseQuote; //adds finalized quote as quote value to row in table for given user

                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)//int? means nullable int
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
                decimal baseQuote = 50.00m;

                //Age Checks
                DateTime now = DateTime.Now;
                DateTime insureeDOB = insuree.DateOfBirth;
                TimeSpan ageDaysRaw = now - insureeDOB;
                int ageDays = ageDaysRaw.Days;
                bool is18AndUnder = ageDays <= (18 * 365);//add 100
                bool isBetween19And25 = ageDays >= (19 * 365) && ageDays <= (25 * 365);//add 50
                bool isOver25 = ageDays > (25 * 365);//add 25

                //Car checks
                int carYear = insuree.CarYear;
                bool carBefore2000 = carYear < 2000;//add 25
                bool carAfter2015 = carYear > 2015;//add 25
                bool carIsPorsche = insuree.CarMake.ToLower() == "porsche";//add 25
                bool carIs911Carrera = insuree.CarModel.ToLower() == "911 carrera";//add 25

                //User checks
                int tickets = insuree.SpeedingTickets;
                bool hasTickets = tickets > 0;
                decimal priceModifierDUI = 1.25m;
                bool hasDUI = insuree.DUI == true;//add 25 percent to total
                decimal priceModifierFullCoverage = 1.5m;
                bool hasFullCoverage = insuree.CoverageType == true;//add 50 percent to total

                //Quote builder logic based on above checks 
                if (is18AndUnder) baseQuote += 100;
                if (isBetween19And25) baseQuote += 50;
                if (isOver25) baseQuote += 25;

                if (carBefore2000) baseQuote += 25;
                if (carAfter2015) baseQuote += 25;
                if (carIsPorsche) baseQuote += 25;
                if (carIs911Carrera) baseQuote += 25;

                if (hasTickets) baseQuote += tickets * 10;
                if (hasDUI) baseQuote = baseQuote * priceModifierDUI;
                if (hasFullCoverage) baseQuote = baseQuote * priceModifierFullCoverage;

                insuree.Quote = baseQuote; //adds finalized quote as quote value to row in table for given user


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
