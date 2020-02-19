using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Helpers;
using Lab_1.Models;
using Lab_1.Controllers;

namespace Lab_1.Controllers
{
    public class ListController : Controller
    {
     
        public ActionResult SlectionList(string TypeList, string TypeDate)
        
        {
            Storage.Instance.typeDate = TypeDate;
            Storage.Instance.typeList = TypeList;

            if (TypeDate == "CargarArcivo")
            {
                PlayerController playerController = new PlayerController();
                ActionResult go = playerController.UploadPlayerFiles();
                return RedirectToAction("UploadPlayerFiles", "Player");
            }
            else if (TypeDate == "IngresarManual")
            {
                return View();
            }
            else
            {
                return View();
            }
            
        }
 
    }
}
