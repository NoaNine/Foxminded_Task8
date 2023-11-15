using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.WPF.Models.Base;

namespace University.WPF.Models
{
    internal class CourseDTO : BaseModelDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ObservableCollection<GroupDTO> Groups { get; set; }
    }
}
