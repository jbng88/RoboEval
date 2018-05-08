using RoboEval.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace RoboEval.Controllers
{
    [RoutePrefix("api/Transcript")]
    public class TranscriptController : ApiController
    {
        public TranscriptController()
        {
        }

        [Route("GetTranscript")]
        public IHttpActionResult GetTranscript(int studentId)
        {
            try
            {
                var dbContext = new DbContext("RoboEvalEntities");

                var students = dbContext.Database.SqlQuery<Student>("SELECT * FROM Student").ToList();
                var transcripts = dbContext.Database.SqlQuery<Transcript>("SELECT * FROM Transcript").ToList();
                return Json(students.FirstOrDefault(x => x.StudentId == studentId)?.Transcript?.Courses);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("GetAcademicPlan")]
        public IHttpActionResult GetAcademicPlan(int studentId)
        {
            try
            {
                var dbContext = new DbContext("RoboEvalEntities");
                //FirstOrDefault to return first row, ToList is the whole list
                var students = dbContext.Database.SqlQuery<Student>("SELECT * FROM Student").ToList();
                var major = dbContext.Database.SqlQuery<Major>("SELECT * FROM Major").ToList();
                var transcripts = dbContext.Database.SqlQuery<Transcript>("SELECT * FROM Transcipt").ToList();
                var majorId = students.FirstOrDefault(x => x.StudentId == studentId).Transcript.Majors.FirstOrDefault().MajorId;

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

                return Json(coursesNeeded);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

    }
}
