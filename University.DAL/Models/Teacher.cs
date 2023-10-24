using University.DAL.Models.Base;

namespace University.DAL.Models;

public class Teacher : PersonBaseModel
{
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
}
