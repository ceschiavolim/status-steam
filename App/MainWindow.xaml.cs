using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SteamStatusApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewMessage();
        }

        private void ViewMessage()
        {
            if (MustDisplayMessage())
            {
                var result = MessageBox.Show("Go online on Steam?", "Status Automation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    Process.Start("explorer.exe", "steam://friends/status/online");
                }
                else
                {
                    Process.Start("explorer.exe", "steam://friends/status/invisible");
                }
            }
            else
            {
                Process.Start("explorer.exe", "steam://friends/status/online");
            }
            Application.Current.Shutdown();
        }

        private bool MustDisplayMessage()
        {
            TimeSpan startTime = new TimeSpan(8, 0, 0); // 08:00
            TimeSpan endTime = new TimeSpan(18, 0, 0); // 18:00
            if (DateTime.Now.TimeOfDay >= startTime && DateTime.Now.TimeOfDay <= endTime)
            {
                return true;
            }
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return false;
                case DayOfWeek.Monday:
                    return true;
                case DayOfWeek.Tuesday:
                    return true;
                case DayOfWeek.Wednesday:
                    return true;
                case DayOfWeek.Thursday:
                    return true;
                case DayOfWeek.Friday:
                    return true;
                case DayOfWeek.Saturday:
                    return false;
                default:
                    return true;
            }
        }
    }
}