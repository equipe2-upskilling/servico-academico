using System.Collections.Generic;

namespace Academic.Core.Repositories.In
{
    public interface ITeacherRepository
    {
        List<TeacherDto> GetAll();
        TeacherDto Get(int id);
        void Add(TeacherDto dto);
        void Delete(int id);
        void Update(TeacherDto dto, int id);
    }
}
