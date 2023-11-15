using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.WPF.Models.Base;

namespace University.WPF.Models
{
    internal class GroupDTO : BaseModelDTO
    {
        public string Name { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }
        public TeacherDTO? Tutor { get; set; }
        public ObservableCollection<StudentDTO> Students { get; set; }
    }
}
