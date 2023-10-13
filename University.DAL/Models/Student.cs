namespace University.DAL.Models;

public class Student : HumanBaseModel
{
    public int GroupId { get; set; }
    public Group Group { get; set; }
}
