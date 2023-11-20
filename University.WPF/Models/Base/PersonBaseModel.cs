namespace University.WPF.Models.Base
{
    internal class PersonBaseModel : BaseModel
    {
        private string _firstName;
        private string _lastName;
        public string FirstName 
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName 
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
    }
}
