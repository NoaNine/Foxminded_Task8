namespace University.DAL.Models;

public class Group : BaseModel
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public Course Course { get; set; }
    public ICollection<Student> Students { get; set; }
}
