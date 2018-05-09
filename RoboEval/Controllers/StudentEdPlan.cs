using System.Collections.Generic;

namespace RoboEval.Controllers
{
    public class StudentEdPlan
    {
        public int StudentId { get; set; }
        public List<CourseDto> CoursesTaken { get; set; }
        public List<CourseDto> CoursesNeeded { get; set; }
    }
}