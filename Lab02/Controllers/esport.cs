using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Controllers
{
    public class esport : Controller
    {
        // GET: esport
        public ActionResult Index()
        {
            return View();
        }

        // GET: esport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: esport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: esport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: esport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: esport/Edit/5
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

        // GET: esport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: esport/Delete/5
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
