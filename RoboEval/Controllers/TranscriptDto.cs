using System.Collections.Generic;

namespace RoboEval.Controllers
{
    public class TranscriptDto
    {
        public int TranscriptId { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}