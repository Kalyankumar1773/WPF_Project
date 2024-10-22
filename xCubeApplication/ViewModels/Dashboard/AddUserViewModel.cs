using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using xCubeApplication.ClientDAL;
using xCubeApplication.Helpers;
using xCubeApplication.Interfaces;
using xCubeApplication.Models;
using xCubeApplication.Services;

namespace xCubeApplication.ViewModels.Dashboard
{
    public class AddUserViewModel : BaseViewModel
    {
        private IUserRepositoryService _userRepositoryService;

        public AddUserViewModel()
        {
            // _userRepositoryService = userRepositoryService;
            _userRepositoryService = new UserRepositoryService();
        }

        public ObservableCollection<UserDetails> _users = new ObservableCollection<UserDetails>();
        public ObservableCollection<UserDetails> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }
        private string _contactNumber;

        public string ContactNumber
        {
            get => _contactNumber;
            set
            {
                if (value.Length <= 10 && Regex.IsMatch(value, @"^[0-9]*$"))
                {
                    _contactNumber = value;
                    OnPropertyChanged(ContactNumber);
                }
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(Name);
            }
        }
        private string _age;

        public string Age
        {
            get => _age;
            set
            {
                if (value.Length <= 5 && Regex.IsMatch(value, @"^[0-9]*$"))
                {
                    _age = value;
                    OnPropertyChanged(Age);
                }
            }
        }

        private string _dateOfBirth;

        public string DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(DateOfBirth);
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

        private string _profilePicturePath;

        public string ProfilePicturePath
        {
            get => _profilePicturePath;
            set
            {
                _profilePicturePath = value;
                OnPropertyChanged("ProfilePicturePath");
            }
        }

        public ICommand _uploadPictureCommand;
        public ICommand UploadPictureCommand
        {
            get
            {
                return _uploadPictureCommand ?? (_uploadPictureCommand = new RelayCommand((o) =>
                {
                    try
                    {
                        UploadPicture();
                    }
                    catch (Exception ex)
                    {

                    }
                }, (o) => { return true; }));
            }
        }

        public ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand((o) =>
                {
                    try
                    {
                        SaveUser();
                    }
                    catch (Exception ex)
                    {

                    }
                }, (o) => { return true; }));
            }
        }

        public ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand((o) =>
                {
                    try
                    {

                    }
                    catch (Exception ex)
                    {

                    }
                }, (o) => { return true; }));
            }
        }

        public  void SaveUser()
        {
            var existingUser =  _userRepositoryService.GetUserDetails(Name);

            try
            {
                //Check if the user exists
                if (existingUser is  null)
                {
                    // Update the existing user
                    existingUser.Name = Name;
                    existingUser.Age = Age;
                    existingUser.DateOfBirth = DateOfBirth;
                    existingUser.ProfileImagePath = ProfilePicturePath;

                    // Call the update method to save changes
                    _userRepositoryService.UpdateUserAsync(existingUser);

                    MessageBox.Show("User details updated successfully.");
                }
                else
                {
                    // Create a new user record if no existing user was found
                    var newUser = new UserDetails
                    {
                        //ID = Guid.NewGuid().ToString(),  // Generating a new unique ID
                        Name = Name,
                        Age = Age,
                        ContactNumber = ContactNumber,
                        DateOfBirth = DateOfBirth,
                        ProfileImagePath = ProfilePicturePath
                    };

                    // Add the new user to the database
                     _userRepositoryService.AddUser(newUser);

                    MessageBox.Show("User added successfully.");
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void UploadPicture()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select a Profile Picture"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Load the selected image
                var filePath = openFileDialog.FileName;
                ProfilePicturePath = filePath;
                ProfilePicture = new BitmapImage(new Uri(filePath));
                OnPropertyChanged(nameof(ProfilePicture));
            }
        }
    }
}
