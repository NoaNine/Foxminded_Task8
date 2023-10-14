using University.DAL.Models.Base;

namespace University.DAL.Models;

public class Teacher : HumanBaseModel
{
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public ICollection<Group> Groups { get; set; }
}
