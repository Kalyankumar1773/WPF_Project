using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using xCubeApplication.Helpers;

namespace xCubeApplication.ViewModels.Dashboard
{
    public class DetailsViewModel : BaseViewModel
    {

        private string _contactNumber;

        public string ContactNumber
        {
            get => _contactNumber;
            set
            {
                _contactNumber = value;
                OnPropertyChanged(nameof(ContactNumber));
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _age;

        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private string _dateOfBirth;

        public string DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        private BitmapImage _profilePicture;

        public BitmapImage ProfilePicture
        {
            get => _profilePicture;
            set
            {
                _profilePicture = value;
                OnPropertyChanged(nameof(ProfilePicture));
            }
        }
    }
}
