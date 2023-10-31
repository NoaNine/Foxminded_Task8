using University.WPF.Services;

namespace University.WPF.DataModels;

public class StudentDataModel : ObservableObject //TODO delete
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
