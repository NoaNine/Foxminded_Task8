namespace University.DAL.Models;

public class Student : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int GroupId { get; set; }

    public Group Group { get; set; }
}
