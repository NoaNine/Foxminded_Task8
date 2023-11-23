using University.DAL.Models.Base;

namespace University.DAL.Models;

public class Student : PersonBaseModel
{
    public int? GroupId { get; set; }
    public Group Group { get; set; }
}
