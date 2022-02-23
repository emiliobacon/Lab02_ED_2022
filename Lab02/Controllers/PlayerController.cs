using ClassLibrary1;
using CsvHelper;
using Lab02.Helpers;
using Lab02.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Lab02.Controllers
{
    public class PlayerController : Controller
    {
        public static string log;

        Stopwatch stopwatch = new Stopwatch();
        // GET: PlayerController
        public ActionResult Index()
        {
            return View(Data.Instance.playerList);
        }

        // GET: PlayerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlayerController/Create
        public ActionResult Create()
        {
            return View(new PlayerModel());
        }

        // POST: PlayerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                PlayerModel.Save(new PlayerModel
                {
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    KDA = int.Parse(collection["KDA"]),
                    CreepScore = int.Parse(collection["CreepScore"]),
                    Rol = collection["Rol"],
                    Team = collection["Team"],
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlayerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlayerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //leer csv 

        [HttpGet]

        public IActionResult Index(GenericList<PlayerModel> players = null)
        {
            players = players == null ? new GenericList<PlayerModel>() : players;
            return View(Data.Instance.playerList);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            //upload csv 
            string fileName = $"{ hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            //end

            var players = this.GetPlayerList(file.FileName);
            return Index(players); //cambio aqui
        }

        private GenericList<PlayerModel> GetPlayerList(string fileName)
        {
            GenericList<PlayerModel> player = new GenericList<PlayerModel>();

            //region 
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var players = csv.GetRecord<PlayerModel>();
                    Data.Instance.playerList.Add(players); ///////add a la lista doble
                }
            }
            //end region

            //create CSV
            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Data.Instance.playerList);
            }
            //end

            return Data.Instance.playerList;
        }

        public ActionResult SearchPlayer(string search)
        {
            
            ViewData["GetPlayerImplemented"] = search;
            var playerRequest = from x in Data.Instance.playerList select x;
            if (!String.IsNullOrEmpty(search))
            {
                stopwatch.Restart();
                stopwatch.Start();
                //Delegado
                playerRequest = playerRequest.Where(x => x.Name.Contains(search) || x.LastName.Contains(search) ||
                x.Rol.Contains(search) || x.KDA.ToString().Contains(search) || x.CreepScore.ToString().Contains(search)
                || x.Team.Contains(search));
                stopwatch.Stop();
                log += "Time elapsed on searching on handcrafted list: " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "\n";
            }
            return View(playerRequest);
        }
    }
}
