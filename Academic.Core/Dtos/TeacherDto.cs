

namespace Academic.Core.Dtos
{
    public class TeacherDto : UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
