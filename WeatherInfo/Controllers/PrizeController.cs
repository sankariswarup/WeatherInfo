using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherInfo.Models;

namespace WeatherInfo.Controllers
{
    public class PrizeController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: /Prize/
        public ActionResult Index()
        {
            return View(db.Prizes.ToList());
        }
        
        public ActionResult Clear(FormCollection collection)
        {
            // This will clear whatever form items have been populated
            ModelState.Clear();

            return RedirectToAction("Create"); 
        }
        // GET: /Prize/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prize prize = db.Prizes.Find(id);
            if (prize == null)
            {
                return HttpNotFound();
            }
            return View(prize);
        }

        // GET: /Prize/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Prize/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Name,BirthDate,Email")] Prize prize)
        {
            var name = prize.Name;
            var names = (from x in db.Prizes
                        where x.Name == name
                        select x).ToList();
            var email = prize.Email;
            var emails = (from y in db.Prizes
                         where y.Email == email
                         select y).ToList();
            if (ModelState.IsValid)
            {
                if (names.Count > 0)
                    ViewBag.Duplicate = "Name already exists in the database";
                else if (emails.Count > 0)
                    ViewBag.DuplicateEmail = "Email already exists in the database";
                else
                {
                    db.Prizes.Add(prize);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(prize);
        }

        // GET: /Prize/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prize prize = db.Prizes.Find(id);
            if (prize == null)
            {
                return HttpNotFound();
            }
            return View(prize);
        }

        // POST: /Prize/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Name,BirthDate,Email")] Prize prize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prize);
        }

        // GET: /Prize/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prize prize = db.Prizes.Find(id);
            if (prize == null)
            {
                return HttpNotFound();
            }
            return View(prize);
        }

        // POST: /Prize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Prize prize = db.Prizes.Find(id);
            db.Prizes.Remove(prize);
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
