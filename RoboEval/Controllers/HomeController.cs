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
        public List<Course> GetAllCoursesStillNeededForMajor(int majorId, int studentId)
        {
            try
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            //majorCourses.Any(x => x.MajorId == 5);
            //majorCourses.FirstOrDefault(x => x.MajorId == 5);
            //majorCourses.(x => x.MajorId == 5);
        }


        //FUNCTION TO DISPLAY STUDENT'S TRANSCRIPT (LIST COURSES TAKEN)
        public IEnumerable<Course> DisplayStudentsTranscript(int studentId, int transcriptId)
        {
            try
            {
                var dbContext = new DbContext("RoboEvalEntities");

                var students = dbContext.Database.SqlQuery<Student>("SELECT * FROM Student").ToList();
                var transcripts = dbContext.Database.SqlQuery<Transcript>("SELECT * FROM Transcript").ToList();
                return transcripts.FirstOrDefault(x => x.TranscriptId == transcriptId)?.Courses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


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
