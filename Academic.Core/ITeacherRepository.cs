using System.Collections.Generic;

namespace Academic.Domain
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
