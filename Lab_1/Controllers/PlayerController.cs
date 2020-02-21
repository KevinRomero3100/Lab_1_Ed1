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
        Services s = new Services();

        public ActionResult Index()
        {

            if (Storage.Instance.ListProp)
            {
                return view(Storage.Instance.playerListProp);
            }
            else
            {
                return view(Storage.Instance.playerLitstCshap);
            }
        }

        public ActionResult Create()
        {
            return View();

            /*
             <form method="post" enctype="multipart/form-data">
    Nombre: <input type="text" name="Nombre" /><br />
    Apellido: <input type="text" name="Apellido" /><br />
    Club: <input type="text" name="´Club" /><br />
    Posición: <input type="text" name="´Posición" /><br />
    Salario: <input type="number" name="Salario" />
    <button>Registrar</button>
</form>
             */



        }

        public ActionResult Create(string Lastname, strong Firstname, string Club, string Position, float Basesalary, float guaranteedCompensation, int Id)
        {
            try
            {
                Player player = new Player(Lastname, Firstname, Club, Position, Basesalary);

                var Exito = s.savePlayers(jugador);
                if (!Exito)
                    ViewBag.Mensaje = "Jugador registrado exitosamente";
                else
                    ViewBag.Mensaje = "Jugador ya registrado anteriormente";
                return View();
            }
            catch
            {
                viewBag.Mensaje = "Ha ocurrido un error";
                return view();
            }
        }

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
        public ActionResult search_LastName(string LastName)
        {
            Player Player01 = new Player { last_name = LastName };
            return SearchPlayer(Player.ComparateLastName, LastName);
        }
        public ActionResult search_FirstName(string FirstName)
        {
            Player Player01 = new Player { first_name = FirstName };
            return SearchPlayer(Player.ComparateFirstName, FirstName);
        }
        public ActionResult search_position(string Position)
        {
            Player Player01 = new Player { position = Position };
            return SearchPlayer(Player.ComparatePosition, Position);
        }
        public ActionResult search_BaseSalary(float Salary)
        {
            Player Player01 = new Player { base_salary = Salary };
            return SearchPlayer(Player.ComparateSalary, Salary);
        }

        public ActionResult SearchPlayers(Comparison<Player> Gamer, Player Player01)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            if (Storage.Instance.playerListProp)
            {
                for (int i = 0; i < Storage.Instance.playerListProp.Count; i++)
                {
                    if (position.Invoke(parametro.Invoke(Storage.Instance.playerListProp.Get(i), j1)))
                    {
                        //resultado
                    }
                }
            }
            else
            {
                for (int i = 0; i < Storage.Instance.PlayerListCshap.Count; i++)
                {
                    if (position.Invoke(parametro.Invoke(Storage.Instance.PlayerListCshap[i], j1)))
                    {
                        //Resultado
                    }
                }
            }
            timer.Stop();
            Storage.Instance.Add(new Tiempo { "Tiempo de búsqueda: " + timer.Elapsed });
        }
    }
}
