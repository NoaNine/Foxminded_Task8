using System.Collections.ObjectModel;
using University.WPF.ViewModel.Base;

namespace University.WPF.DataModels;

public class GroupDataModel : BaseViewModel
{
    public string Name { get; set; }
    public ObservableCollection<StudentDataModel> Students { get; set; }
    public GroupDataModel(ObservableCollection<StudentDataModel> students)
    {
        Students = students;
    }
}
