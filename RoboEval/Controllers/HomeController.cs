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
            ViewBag.Title = "RoboEval";

            return View();
        }
        //Courses Comparison Logic
        


        //FUNCTION TO DISPLAY STUDENT'S TRANSCRIPT (LIST COURSES TAKEN)
        


        //FUNCTION TO ADD COURSES ONTO A STUDENT'S TRANSCRIPT (MODIFY TRANSCRIPT)
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

        //      START NEW ADDITIONS 
         
        //GRADE CHANGE FUNCTION 
        public void ModifyGrade(Course grade)
        {
            try
            {
                var dbContext = new DbContext("RoboEvalEntities");

                dbContext.Set<Course>().Add(grade);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
        //END GRADE CHANGE FUNCTION


      //public void DisplaySuggestedEdPlan() => GetAllCoursesStillNeededForMajor()
        private void GetAllCoursesStillNeededForMajor()
        {
            throw new NotImplementedException();
        }

          //END NEW ADDITIONS
    }
}
