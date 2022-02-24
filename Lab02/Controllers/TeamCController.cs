using Lab02.Helpers;
using Lab02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Controllers
{
    public class TeamCController : Controller
    {
        // GET: TeamCController
        public ActionResult Index()
        {
            return View(Data.Instance.teamCList);
        }

        // GET: TeamCController/Details/5
        public ActionResult Details(int id)
        {
            var model = Data.Instance.teamCList.Find(team => team.id == id);
            return View(model);
        }

        // GET: TeamCController/Create
        public ActionResult Create()
        {
            return View(new TeamModel());
        }

        // POST: TeamCController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var response = TeamModel.SaveC(new TeamModel
                {
                    id = int.Parse(collection["id"]),
                    CreationDate = DateTime.Parse(collection["CreationDate"]),
                    Coach = collection["Coach"],
                    League = collection["League"],
                    TeamName = collection["TeamName"],
          
                });

                if (response)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag["Error"] = "Error creando nuevo elemento";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamCController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Data.Instance.teamCList.Find(team => team.id == id);
            return View(model);
        }

        // POST: TeamCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                TeamModel.Edit(id, new TeamModel
                {
                    TeamName = collection["TeamName"],
                    Coach = collection["Coach"],
                    CreationDate = DateTime.Parse(collection["CreationDate"]),
                    id = id, 
                    League = collection["League"],
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamCController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = Data.Instance.teamCList.Find(team => team.id == id);
            return View();
        }

        // POST: TeamCController/Delete/5
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
    }
}
