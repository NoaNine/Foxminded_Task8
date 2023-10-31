using System.Collections.ObjectModel;
using University.WPF.Services;

namespace University.WPF.DataModels;

public class CourseDataModel : ObservableObject //TODO delete
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ObservableCollection<GroupDataModel> Groups { get; set; }

    public CourseDataModel(ObservableCollection<GroupDataModel> groups)
    {
        Groups = groups;
    }
}
