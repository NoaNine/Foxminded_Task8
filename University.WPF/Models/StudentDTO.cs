using University.WPF.Models.Base;

namespace University.WPF.Models
{
    internal class StudentDTO : PersonBaseModelDTO
    {
        private int _groupId;
        private GroupDTO _group;
        public int GroupId 
        { 
            get => _groupId;
            set
            {
                _groupId = value;
                OnPropertyChanged();
            }
        }
        public GroupDTO Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged();
            }
        }
    }
}
