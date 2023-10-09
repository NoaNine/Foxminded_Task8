namespace University.DAL.Models;

public class Teacher : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int GroupId { get; set; }

    public ICollection<Group> Groups { get; set; }
}
