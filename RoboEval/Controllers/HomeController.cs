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
        public List<Course> GetAllCoursesStillNeededForMajor(int majorId, int studentId)
        {
            var dbContext = new DbContext("RoboEvalEntities");
            //FirstOrDefault to return first row, ToList is the whole list
            var students = dbContext.Database.SqlQuery<Student>("SELECT * FROM Student").ToList();
            var major = dbContext.Database.SqlQuery<Major>("SELECT * FROM Major").ToList();
            var transcripts = dbContext.Database.SqlQuery<Transcript>("SELECT * FROM Transcipt").ToList();

            var majorRequirements = major.FirstOrDefault(x => x.MajorId == majorId).Courses;
            var transcriptId = students.FirstOrDefault(student => student.StudentId == studentId).TranscriptId;
            var coursesTaken = transcripts.FirstOrDefault(x => x.TranscriptId == transcriptId).Courses;
            var coursesNeeded = new List<Course>();

            foreach (var course in majorRequirements)
            {
                if (!coursesTaken.Any(x => x.CourseId == course.CourseId))
                {
                    coursesNeeded.Add(course);              
                }
            }

            return coursesNeeded;
            //majorCourses.Any(x => x.MajorId == 5);
            //majorCourses.FirstOrDefault(x => x.MajorId == 5);
            //majorCourses.(x => x.MajorId == 5);
        }
    }
}
