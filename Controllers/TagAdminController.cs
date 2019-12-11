using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DreamGames.Database.Context;
using DreamGames.Database.Games;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dreamgames.Controllers
{
    public class TagAdminController : Controller
    {
        private readonly ContentContext _context;
        public TagAdminController(ContentContext context)
        {
            _context = context;
        }
        // GET: TagAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: TagAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagAdmin/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTag(Tag taggy)
        {
            
            try
            {
                _context.Tags.Add(taggy);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TagAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TagAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TagAdmin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}