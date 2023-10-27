using System.Collections.ObjectModel;
using University.DAL.Models;
using University.WPF.ViewModel.Base;

namespace University.WPF.DataModels;

public class CourseDataModel : BaseViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ObservableCollection<GroupDataModel> Groups { get; set; }
    public CourseDataModel(ObservableCollection<GroupDataModel> groups)
    {
        Groups = groups;
    }
}
