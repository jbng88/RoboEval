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

                var coursesTaken = dbContext.Set<CoursesTaken>()
                    .Where(x => x.Transcript.Students.FirstOrDefault().StudentId == studentId)
                    .Include(x => x.Transcript.Students)
                    .Include(x => x.Course)
                    .ToList();

                return Json(coursesTaken.Select(x => new CourseDto
                {
                    CourseId = x.CourseId,
                    Name = x.Course.Name,
                    Grade = x.Grade
                }));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("GetStudentEdPlan")]
        public IHttpActionResult GetStudentEdPlan(int studentId)
        {
            try
            {
                var dbContext = new DbContext("RoboEvalEntities");
                var majorId = dbContext.Set<Student>()
                    .Include(x => x.Transcript.Majors)
                    .FirstOrDefault(x => x.StudentId == studentId)
                    .Transcript.Majors.FirstOrDefault().MajorId;

                var majorRequirements = dbContext.Set<Course>().Where(x => x.Majors.Any(y => y.MajorId == majorId)).ToList();
                var transcriptId = dbContext.Set<Student>().FirstOrDefault(student => student.StudentId == studentId).TranscriptId;

                var edPlan = new StudentEdPlan
                {
                    StudentId = studentId,
                    CoursesTaken = dbContext.Set<CoursesTaken>().Where(x => x.TranscriptId == transcriptId)
                        .Select(x => new CourseDto
                        {
                            CourseId = x.CourseId,
                            Name = x.Course.Name,
                            Grade = x.Grade
                        }).ToList(),
                    CoursesNeeded = new List<CourseDto>()                        
                };

                foreach (var course in majorRequirements)
                {
                    if (!edPlan.CoursesTaken.Any(x => x.CourseId == course.CourseId))
                    {
                        edPlan.CoursesNeeded.Add(new CourseDto
                        {
                            CourseId = course.CourseId,
                            Name = course.Name
                        });
                    }
                }

                return Json(edPlan);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("ModifyTranscript")]
        public IHttpActionResult ModifyTranscript([FromBody]TranscriptDto transcriptDto)
        {
            try
            {
                var dbContext = new DbContext("RoboEvalEntities");
                var coursesTaken = dbContext.Set<CoursesTaken>().Where(x => x.TranscriptId == transcriptDto.TranscriptId).ToList();

                foreach (var course in coursesTaken)
                {
                    if (course.Grade == null)
                    {
                        var grade = transcriptDto.Courses.FirstOrDefault(x => x.CourseId == course.CourseId).Grade;
                        course.Grade = string.IsNullOrEmpty(grade) ? null : grade;
                    }
                }
                dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
