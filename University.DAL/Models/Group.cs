using University.DAL.Models.Base;

namespace University.DAL.Models;

public class Group : BaseModel
{
    public string Name { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
    public Teacher? Tutor { get; set; }
    public ICollection<Student> Students { get; set; }
}
