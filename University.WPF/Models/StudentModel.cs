using University.WPF.Models.Base;

namespace University.WPF.Models
{
    internal class StudentModel : PersonBaseModelData
    {
        private int? _groupId;
        private GroupModel _group;
        public int? GroupId 
        { 
            get => _groupId;
            set
            {
                _groupId = value;
                OnPropertyChanged();
            }
        }
        public GroupModel Group
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
