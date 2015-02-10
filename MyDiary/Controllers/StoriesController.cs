using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyDiary.Models;
using System.IO;
using PagedList;

namespace MyDiary.Controllers
{
    public class StoriesController : Controller
    {
        private StoryDBEntities5 db = new StoryDBEntities5();

        // GET: Stories

        public ActionResult Index(string id, string searchString, int? page, int? itemsPerPage)
        {



            var story = from b in db.Story
                        select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                story = story.Where(s => s.Story_Name.Contains(searchString));
            }



            int pageSize = itemsPerPage ?? 6;
            int pageNumber = (page ?? 1);
            int pageCount = story.Count() / pageSize;
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageNumber > pageCount)
            {
                pageCount = pageNumber;
            }
            var pagableSource = story.OrderBy(stry => stry.ID).ToPagedList(pageNumber, pageSize);
            ViewBag.pages = pagableSource.PageCount;
            ViewBag.pageNumber = pageNumber;
            return View(pagableSource);
        }


        // GET: Stories/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Story.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: Stories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Story_Name,Create_Date,Story1,Rating")] Story story, HttpPostedFileBase Image)
        {
            MemoryStream target = new MemoryStream();
            Image.InputStream.CopyTo(target);
            story.Image = target.ToArray();


            try
            {
                if (ModelState.IsValid)
                {
                    db.Story.Add(story);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return View(story);
        }



        // GET: Stories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Story.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Story_Name,Create_Date,Story1,Rating")] Story story, HttpPostedFileBase Image)
        {
            if (Image == null)
            {
                //Story tempStory = db.Story.Find(story.ID);
                //story.Image = tempStory.Image;
            }
            else
            {
                MemoryStream target = new MemoryStream();
                Image.InputStream.CopyTo(target);
                story.Image = target.ToArray();
            }

            if (ModelState.IsValid)
            {
                db.Entry(story).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story);
        }

        // GET: Stories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Story.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = db.Story.Find(id);
            db.Story.Remove(story);
            db.SaveChanges();
            return RedirectToAction("Index", "Stories");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult RenderPhoto(int imageId)
        {
            Story story = db.Story.Find(imageId);
            return File(story.Image ?? new byte[] { }, "image/jpeg");
        }

        public ActionResult GetImage(int stars)
        {
            if (stars == 1)
            {
                return File("../Img/1smiling-gold-star.png", "url");
            }
            if (stars == 2)
            {
                return File("../Img/2smiling-gold-star.png", "url");
            }
            if (stars == 3)
            {
                return File("../Img/3smiling-gold-star.png", "url");
            }
            return File("", "");
        }

        public ActionResult Caroucel()
        {
            return View();
        }

        public ActionResult AboutMe()
        {
            return View();
        }

        public ActionResult NewImg(string newImg)
        {
            return File("../Img/Pic/" + newImg, "image/jpeg");
        }
    }
}
