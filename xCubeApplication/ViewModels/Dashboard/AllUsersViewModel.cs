using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using xCubeApplication.Helpers;
using xCubeApplication.Interfaces;
using xCubeApplication.Models;
using xCubeApplication.Services;

namespace xCubeApplication.ViewModels.Dashboard
{
    public class AllUsersViewModel : BaseViewModel
    {
        private UserDetails _selectedUser;
        private IUserRepositoryService _userRepositoryService;
        public ObservableCollection<UserDetails> Users { get; set; }

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
            _userRepositoryService = new UserRepositoryService();
            List<UserDetails> AllUsers = _userRepositoryService.GetAllUserDetails();
            Users = new ObservableCollection<UserDetails>(AllUsers);
        }
    }
}
