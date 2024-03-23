using Mvc_Images_Added.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Images_Added.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DbPicturesAddEntities2 db = new DbPicturesAddEntities2();
        public ActionResult Index()
        {
            var List = db.Table_Pictures.ToList();
            return View(List);
        }

        [HttpGet]
        public ActionResult AddImages()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddImages([Bind(Include = "ID,Pictures")] Table_Pictures p, HttpPostedFileBase fileBase)
        {
            if (fileBase != null)
            {
                string filePath = Path.GetFileName(fileBase.FileName);
                var uploadLocation = Path.Combine(Server.MapPath("~/Images"), filePath);
                fileBase.SaveAs(uploadLocation);
                p.Pictures = "/Images/" + filePath;
            }
            db.Table_Pictures.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }


}