using System.Collections.ObjectModel;
using University.WPF.Models.Base;

namespace University.WPF.Models
{
    internal class CourseDTO : BaseModelDTO
    {
        private string _name;
        private string _description;
        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Description 
        { 
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<GroupDTO> Groups { get; set; }
    }
}
