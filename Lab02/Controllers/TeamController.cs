using ClassLibrary1;
using Lab02.Helpers;
using Lab02.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using CsvHelper;
using System.Globalization;
using System;
using System.Linq;

namespace Lab02.Controllers
{
    public class TeamController : Controller
    {
        // GET: TeamController
        public ActionResult Index()
        {
            return View(Data.Instance.teamList);
        }

        // GET: TeamController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: TeamController/Create
        public ActionResult Create()
        {
            return View(new TeamModel());
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                TeamModel.Save(new TeamModel
                {
                    id = int.Parse(collection["id"]),
                    TeamName = collection["TeamName"],
                    Coach = collection["Coach"],
                    CreationDate = DateTime.Parse(collection["CreationDate"]),
                    League = collection["League"],


                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public ActionResult Edit(int id)
        {
            TeamModel teeam;
            int i;
            for (i = 0; Data.Instance.teamList.Length > i; i++)
            {
                teeam = Data.Instance.teamList.ElementAt(i);
                if (teeam.id == id)
                {
                    break;
                }
            }
            teeam = Data.Instance.teamList.ElementAt(i);
            return View(teeam);
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            int i;
            try
            {
                TeamModel teeam;

                for (i = 0; Data.Instance.teamList.Length > i; i++)
                {
                    teeam = Data.Instance.teamList.ElementAt(i);

                    if (teeam.id == id)
                    {
                        break;
                    }
                }
                teeam = Data.Instance.teamList.ElementAt(i);
                teeam.Coach = collection["Coach"];
                teeam.League = collection["League"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            TeamModel teeam;
            int i;
            for (i = 0; Data.Instance.teamList.Length > i; i++)
            {
                teeam = Data.Instance.teamList.ElementAt(i);
                if (teeam.id == id)
                {
                    break;
                }
            }
            teeam = Data.Instance.teamList.ElementAt(i);
            return View(teeam);
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            int i;
            try
            {
                TeamModel teeam;

                for (i = 0; Data.Instance.teamList.Length > i; i++)
                {
                    teeam = Data.Instance.teamList.ElementAt(i);

                    if (teeam.id == id)
                    {
                        break;
                    }
                }
                Data.Instance.teamList.DeleteP(i);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //leer csv 

        [HttpGet]

        public IActionResult Index(GenericList<TeamModel> teams = null)
        {
            teams = teams == null ? new GenericList<TeamModel>() : teams;
            return View(Data.Instance.teamList);
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

            var teams = this.GetTeamsList(file.FileName);
            return Index(teams); //cambio aqui
        }

        private GenericList<TeamModel> GetTeamsList(string fileName)
        {
            GenericList<TeamModel> team = new GenericList<TeamModel>();

            //region 
            var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fileName;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var teams = csv.GetRecord<TeamModel>();
                    Data.Instance.teamList.Add(teams); ///////add a la lista doble
                }
            }
            //end region

            //create CSV
            path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\FilesTo"}";
            using (var write = new StreamWriter(path + "\\NewFile.csv"))
            using (var csv = new CsvWriter(write, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Data.Instance.teamList);
            }
            //end

            return Data.Instance.teamList;
        }
        public ActionResult SearchTeam(string search)
        {

            ViewData["GetPlayerImplemented"] = search;
            var team = from x in Data.Instance.teamList select x;
            if (!String.IsNullOrEmpty(search))
            {

                //Delegado
                team = team.Where(x => x.TeamName.Contains(search) || x.Coach.Contains(search) ||
                x.League.Contains(search) || x.CreationDate.ToString().Contains(search) || x.id.ToString().Contains(search));

            }
            return View(team);
        }


    }
}
