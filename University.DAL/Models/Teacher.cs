namespace University.DAL.Models
{
    public class Teacher : BaseModel
    {
        public int GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
