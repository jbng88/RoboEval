using RoboEval.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoboEval.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        //Courses Comparison Logic
        


        //FUNCTION TO DISPLAY STUDENT'S TRANSCRIPT (LIST COURSES TAKEN)
        

        public void AddClass(Course course)
        {
            try
            {
                var dbContext = new DbContext("RoboEvalEntities");

                dbContext.Set<Course>().Add(course);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
