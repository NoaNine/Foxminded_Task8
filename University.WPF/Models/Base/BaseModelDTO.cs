using University.WPF.Services;

namespace University.WPF.Models.Base
{
    internal class BaseModelDTO : ObservableObject
    {
        private int _id;
        public int Id 
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
    }
}
