using Lab02.Helpers;
using Lab02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

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
                    CreationDate = int.Parse(collection["CreationDate"]),
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
            return View();
        }

        // POST: TeamController/Edit/5
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

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamController/Delete/5
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

        //Importar archivo CSV 

        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase postedFile)
        //{
        //    List<TeamModel> customers = new List<TeamModel>();
        //    string filePath = string.Empty;
        //    if (postedFile != null)
        //    {
        //        string path = Server.MapPath("~/Uploads/");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        filePath = path + Path.GetFileName(postedFile.FileName);
        //        string extension = Path.GetExtension(postedFile.FileName);
        //        postedFile.SaveAs(filePath);

        //        //Read the contents of CSV file.
        //        string csvData = System.IO.File.ReadAllText(filePath);

        //        //Execute a loop over the rows.
        //        foreach (string row in csvData.Split('\n'))
        //        {
        //            if (!string.IsNullOrEmpty(row))
        //            {
        //                customers.Add(new TeamModel
        //                {
        //                    id = Convert.ToInt32(row.Split(',')[0]),
        //                    TeamName = row.Split(',')[1],
        //                    Coach = row.Split(',')[2]
        //                });
        //            }
        //        }
        //    }

        //    return View(customers);
        //}


       

       
    }
}
