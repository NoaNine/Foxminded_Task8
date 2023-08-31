namespace University.DAL.Models;

public class Student : BaseModel
{
    public int GroupId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Group Group { get; set; }
}
