using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace University.WPF.Infrastructure;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string property = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(property));
    }
}
