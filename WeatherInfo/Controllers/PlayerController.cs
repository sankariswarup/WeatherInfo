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
    public class PlayerController : Controller
    {
        Image newImage = new Image();
        ImageController imageCntrl = new ImageController();
        private NFLDBContext db = new NFLDBContext();

        // GET: /Player/
        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Statistics);
            return View(players.ToList());
        }
        public ActionResult Upload(Image photo)
        {
           
           
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

                imageCntrl.Create(newImage);
                db.Images.Add(newImage);
                db.SaveChanges();
                //Session["ImageId"] = newImage.ImageId;
            }

            return View("Create") ;
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
                    fileType = image.ImageName;
                }
            }
            type = fileType;
            return fileBytes;
        }
        public ActionResult Show(int? id)
        {
            string mime;
            byte[] bytes = LoadImage(id.Value, out mime);
            return File(bytes, mime);
  
     
        }
        // GET: /Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            Image image = db.Images.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: /Player/Create
        public ActionResult Create()
        {
            ViewBag.statisticsId = new SelectList(db.Statistics, "StatisticsId", "TeamOrPlayer");
             return View();
        }

        // POST: /Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
        [Bind(Include="PlayerId,PlayerPoS,PlayerNumber,PlayerName,PlayerStatus,ImageId,statisticsId")] Player player)
        {
            if (ModelState.IsValid)
            {
               
               // db.Images.Add(image);
                HttpPostedFileBase file = Request.Files["OpeningFile"];
                if (file != null)
                {
                    newImage.ImageName = file.FileName;
                    newImage.ImageAlt = file.FileName;
                    newImage.ContentType = file.ContentType;

                    Int32 length = file.ContentLength;
                    byte[] tempImage = new byte[length];
                    file.InputStream.Read(tempImage, 0, length);
                    newImage.ImageData = tempImage;

                    imageCntrl.Create(newImage);
                    db.Images.Add(newImage);
                    player.ImageId = newImage.ImageId;
                    db.Players.Add(player);
                    db.SaveChanges();
                    ViewBag.ImageId = new SelectList(db.Images, "ImageId", "ImageId", newImage.ImageId);
                    //Session["ImageId"] = newImage.ImageId;
                }
             

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.statisticsId = new SelectList(db.Statistics, "StatisticsId", "TeamOrPlayer", player.statisticsId);
           //ViewBag.ImageId = new SelectList(db.Images, "ImageId", "ImageId", newImage.ImageId);
            return View(player);
        }

        // GET: /Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Player player = db.Players.Find(id);
            Image image = db.Images.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.statisticsId = new SelectList(db.Statistics, "StatisticsId", "TeamOrPlayer", player.statisticsId);
            return View(player);
        }

        // POST: /Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PlayerId,PlayerPoS,PlayerNumber,PlayerName,PlayerStatus,ImageId,statisticsId")] Player player
            )
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(newImage).State = EntityState.Modified;
                //player.ImageId = newImage.ImageId;
                ViewBag.ImageId = new SelectList(db.Images, "ImageId", "ImageId", newImage.ImageId);
                db.Entry(player).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.statisticsId = new SelectList(db.Statistics, "StatisticsId", "TeamOrPlayer", player.statisticsId);
            ViewBag.ImageId = new SelectList(db.Images, "ImageId", "ImageId", newImage.ImageId);
            return View(player);
        }

        // GET: /Player/Delete/5
        public ActionResult Delete(int? id, int? imid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: /Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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
