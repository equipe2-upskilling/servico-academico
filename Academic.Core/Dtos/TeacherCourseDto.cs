using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Core.Dtos
{
    public class TeacherCourseDto
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}
