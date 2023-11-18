using University.WPF.Infrastructure;

namespace University.WPF.Models.Base
{
    internal class BaseDTO : ObservableObject
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
