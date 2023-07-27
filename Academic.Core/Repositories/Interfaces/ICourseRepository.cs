using Academic.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Core.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<TeacherCourseDto>> GetAllbyTeacher(int id);

    }
}
