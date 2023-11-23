using University.WPF.Infrastructure;

namespace University.WPF.Models.Base
{
    internal abstract class BaseModelData : ObservableObject
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
