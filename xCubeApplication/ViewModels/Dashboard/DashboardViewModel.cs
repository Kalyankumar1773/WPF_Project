using System.Windows.Input;
using xCubeApplication.Helpers;

namespace xCubeApplication.ViewModels.Dashboard
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {
            CurrentViewModel = new AllUsersViewModel();
        }


        private object _currentViewModel;

        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }


        public ICommand _showAddUserViewCommand;
        public ICommand ShowAddUserViewCommand
        {
            get
            {
                return _showAddUserViewCommand ?? (_showAddUserViewCommand = new RelayCommand((o) =>
                {
                    try
                    {
                        CurrentViewModel = new AddUserViewModel();
                    }
                    catch (Exception ex)
                    {

                    }
                }, (o) => { return true; }));
            }
        }
        public ICommand _showAllUsersViewCommand;
        public ICommand ShowAllUsersViewCommand
        {
            get
            {
                return _showAllUsersViewCommand ?? (_showAllUsersViewCommand = new RelayCommand((o) =>
                {
                    try
                    {
                        CurrentViewModel = new AllUsersViewModel();
                    }
                    catch (Exception ex)
                    {

                    }
                }, (o) => { return true; }));
            }
        }

        public ICommand _showMapViewCommand;
        public ICommand ShowMapViewCommand
        {
            get
            {
                return _showMapViewCommand ?? (_showMapViewCommand = new RelayCommand((o) =>
                {
                    try
                    {
                        CurrentViewModel = new MapViewModel();
                    }
                    catch (Exception ex)
                    {

                    }
                }, (o) => { return true; }));
            }
        }

    }
}
