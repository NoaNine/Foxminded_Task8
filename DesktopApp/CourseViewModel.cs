using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using University.DAL.Models;

namespace MVVM
{
    public class CourseViewModel : INotifyPropertyChanged
    {
        private Course _course;

        public ObservableCollection<Group> Groups { get; set; }
        public Course course
        {
            get { return _course; }
            set
            {
                _course = value;
                OnPropertyChanged("course");
            }
        }

        public CourseViewModel()
        {
            //Groups = new ObservableCollection<Group>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}