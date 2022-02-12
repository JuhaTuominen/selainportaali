using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaMODEPortal.Models;

namespace SeaMODEPortal.Controllers
{
    public class FileController : Controller
    {

        // GET: File

        public ActionResult Index()
        {
            seamodeEntities3 entities = new seamodeEntities3();
            return View(entities.Data.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            if(postedFile != null) 
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(postedFile.InputStream))
                {
                    bytes = br.ReadBytes(postedFile.ContentLength);
                }
                seamodeEntities3 entities = new seamodeEntities3();
                entities.Data.Add(new Data
                {
                    Name = Path.GetFileName(postedFile.FileName),
                    ContentType = postedFile.ContentType,
                    Data1 = bytes
                });
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LoginMessage = "choose file. ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            seamodeEntities3 entities = new seamodeEntities3();
            Data file = entities.Data.ToList().Find(p => p.DataID == fileId.Value);
            return File(file.Data1, file.ContentType, file.Name);
        }

        public ActionResult DataTable()
        {
            seamodeEntities3 db = new seamodeEntities3();
            var data = db.Data;
            return View(data.ToList());
        }
    }
}
