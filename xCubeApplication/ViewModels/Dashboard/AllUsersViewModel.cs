using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using xCubeApplication.Helpers;
using xCubeApplication.Models;

namespace xCubeApplication.ViewModels.Dashboard
{
    public class AllUsersViewModel : BaseViewModel
    {
        private UserDetails _selectedUser;

        // Observable collection of users
        public ObservableCollection<UserDetails> Users { get; set; }

        // Selected user from the list
        public UserDetails SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public AllUsersViewModel()
        {
            Users = new ObservableCollection<UserDetails>
         {
             //new UserDetails { Name = "John Doe", Age = "30", DateOfBirth = "1994-5-15", ContactNumber = "1234567890",ProfileImagePath="C:\\Users\\ajays\\OneDrive\\画像\\Screenshots\\Screenshot 2024-07-31 220837.png" },
             //new UserDetails { Name = "Jane Smith", Age = "25", DateOfBirth = "1999-5-15", ContactNumber = "0987654321",ProfileImagePath="C:\\Users\\ajays\\OneDrive\\画像\\Screenshots\\Screenshot 2024-07-09 203757.png" }
         };
        }
    }
}
