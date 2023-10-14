using University.DAL.Models.Base;

namespace University.DAL.Models
{
    public class Tutor : HumanBaseModel
    {
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
