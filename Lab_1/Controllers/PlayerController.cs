using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;
using System.IO;
using Genericos.Structures;


namespace Lab_1.Controllers
{
    
    public class PlayerController : Controller
    {
        String route = null;


        public ActionResult UploadPlayerFiles()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadPlayerFiles(HttpPostedFileBase file)
        {
            UploadFilesModel UploadFile = new UploadFilesModel();
            ReadFile readFile = new ReadFile();
            if (file != null) 
            {
                route = Server.MapPath("~/PlayersDataSheet/");
                route += file.FileName;
                UploadFile.UploadFile(route, file);
                ViewBag.Error = UploadFile.error;
                ViewBag.Confirmation = UploadFile.Confirmation;

                readFile.ReadFiles(route);    
            }
            return View();
        }


       
    }
}
