using System.Collections.ObjectModel;
using University.WPF.Services;

namespace University.WPF.DataModels;

public class GroupDataModel : ObservableObject //TODO delete
{
    public string Name { get; set; }
    public ObservableCollection<StudentDataModel> Students { get; set; }

    public GroupDataModel(ObservableCollection<StudentDataModel> students)
    {
        Students = students;
    }
}
