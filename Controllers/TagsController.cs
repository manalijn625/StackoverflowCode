using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverFlow.Models.Repository;
namespace StackOverFlow.Controllers
{
    public class TagsController : Controller
    {
        TagsRepository tagsRepository = new TagsRepository(new StackOverFlowDbContext());
        // GET: Tags
        public ActionResult List()
        {
            var Tags = tagsRepository.GetAll();
            return View(Tags);
        }

        // GET: Tags/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tags/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tags/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tags/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tags/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
