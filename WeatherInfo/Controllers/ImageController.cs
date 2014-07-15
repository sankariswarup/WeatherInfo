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
    public class ImageController : Controller
    {
        private NFLDBContext db = new NFLDBContext();

        // GET: /Image/
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }
        public ActionResult Upload(Image photo)
        {
            Image newImage = new Image();
            HttpPostedFileBase file = Request.Files["file"];
            if (file != null)
            {
                newImage.ImageName = file.FileName;
                newImage.ImageAlt = file.FileName;
                newImage.ContentType = file.ContentType;

                Int32 length = file.ContentLength;
                byte[] tempImage = new byte[length];
                file.InputStream.Read(tempImage, 0, length);
                newImage.ImageData = tempImage;

                Create(newImage);
            }

            return RedirectToAction("Index");
        }

public ActionResult Show(int? id)
{
    string mime;
    byte[] bytes = LoadImage(id.Value, out mime);
    return File(bytes, mime);
}
private byte[] LoadImage(int id, out string type)
{
    byte[] fileBytes = null;
    string fileType = null;
    using (NFLDBContext databaseContext = new NFLDBContext())
    {
        var image = databaseContext.Images.FirstOrDefault(doc => doc.ImageId == id);
        if (image != null)
        {
            fileBytes = image.ImageData;
            fileType = image.ImageAlt;
        }
    }
    type = fileType;
    return fileBytes;
}

        // GET: /Image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: /Image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageId,ImageName,ImageAlt,ContentType,ImageData")]Image image)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(image);
        }

        // GET: /Image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: /Image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageId,ImageName,ImageAlt,ContentType,ImageData")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }

        // GET: /Image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: /Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
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
