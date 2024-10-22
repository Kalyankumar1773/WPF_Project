using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace xCubeApplication.Views.Dashboard
{
    public partial class DashboardView : UserControl
    {
        DispatcherTimer timer;

        double panelWidth;
        bool hidden;
        public DashboardView()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;

            panelWidth = sidePanel.Width;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 5;
                this.btnAddUser.Visibility = Visibility.Visible;
                this.btnAllUsers.Visibility = Visibility.Visible;
                this.btnmap.Visibility = Visibility.Visible;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 5;
                if (sidePanel.Width <= 35)
                {
                    timer.Stop();
                    hidden = true;
                    this.btnAddUser.Visibility = Visibility.Hidden;
                    this.btnAllUsers.Visibility = Visibility.Hidden;
                    this.btnmap.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

            }
        }
    }
}
