using System.Collections.ObjectModel;
using University.WPF.Models.Base;

namespace University.WPF.Models
{
    internal class GroupDTO : BaseModelDTO
    {
        private string _name;
        private string _courseId;
        private CourseDTO _course;
        private TeacherDTO? _tutor;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string CourseId
        {
            get => _courseId;
            set
            {
                _courseId = value;
                OnPropertyChanged();
            }
        }
        public CourseDTO Course
        {
            get => _course;
            set
            {
                _course = value;
                OnPropertyChanged();
            }
        }
        public TeacherDTO Tutor
        {
            get => _tutor;
            set
            {
                _tutor = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<StudentDTO> Students { get; set; }
    }
}
