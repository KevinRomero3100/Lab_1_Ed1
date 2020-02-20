using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;
using System.IO;
using Genericos.Structures;
using Lab_1.Helpers;


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
            return RedirectToAction("PlayersList");
        }

        public ActionResult PlayersList()
        {
            if (Storage.Instance.typeList == "ListaArtesanal")
            {
                return View(Storage.Instance.playersListProp);
            }
            else if (Storage.Instance.typeList == "ListaC#")
            {
                    return View(Storage.Instance.playersListCshap);
                
            }
            else
            {
                return RedirectToAction("UploadPlayerFiles");
            }
            
        }

        public ActionResult Edit(int Id,string Club, string firstName, string lastName, string Position, 
            float baseSalary, float guarnteed  )
        {
            if (Storage.Instance.typeList == "ListaArtesanal")
            {
                var playerModyfy = new Player {id = Id,club =Club,fisrt_name = firstName, last_name= lastName,
                position =Position, base_salary =baseSalary, guaranteed_compensation = guarnteed};



                return RedirectToAction("PlayersList");
            }
            else if (Storage.Instance.typeList == "ListaC#")
            {

                
                return RedirectToAction("PlayersList");


            }
            else
            {
                return RedirectToAction("PlayersList");
            }
        }


        public ActionResult Delete(int Id)//int Id, string Club, string firstName, string lastName, string Position,
        //    float baseSalary, float guarnteed)
        {
            var deletePlayer = new Player
            {
                id = Id
            };
            //    club = Club,
            //    fisrt_name = firstName,
            //    last_name = lastName,
            //    position = Position,
            //    base_salary = baseSalary,
            //    guaranteed_compensation = guarnteed
            //};
            if (Storage.Instance.typeList == "ListaArtesanal")
            {
                Storage.Instance.playersListProp.Del(deletePlayer);
            }
            else if (Storage.Instance.typeList == "ListaC#")
            {
                Storage.Instance.playersListCshap.Remove(deletePlayer);

            }
            return RedirectToAction("PlayersList");
        }

    }
}
