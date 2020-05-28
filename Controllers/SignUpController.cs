using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StackOverFlow.Controllers
{
    public class SignUpController : Controller
    {
        public StackOverFlowDbContext se = new StackOverFlowDbContext();
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    se.Users.Add(user);
                    se.SaveChanges();
                    return Redirect("/Home/Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return View();
            }
        }

        // GET: SignUp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignUp/Edit/5
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

        // GET: SignUp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignUp/Delete/5
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
