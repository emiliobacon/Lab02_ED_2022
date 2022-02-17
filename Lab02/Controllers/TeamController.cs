using Lab02.Helpers;
using Lab02.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //leer csv 

        private IHostingEnvironment Environment;
        public TeamController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        

        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);
                DataTable dt = new DataTable();
                bool firstRow = true;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (firstRow)
                            {
                                foreach (string cell in row.Split(','))
                                {
                                    
                                    dt.Columns.Add(cell.Trim());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                dt.Rows.Add();
                                int i = 0;
                                foreach (string cell in row.Split(','))
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                    i++;
                                }
                            }
                        }
                    }
                }

                return View(dt);
            }

            return View();
        }
    }
}
