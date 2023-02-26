using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevEmporium.Presentation.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    /// 
    public delegate void NavigationHandler();
    public partial class LoginView : UserControl
    {
        public event NavigationHandler ResetPasswordRequested;
        public event NavigationHandler LogInRequested;
        public event NavigationHandler CreateAccountRequested;

        public LoginView()
        {
            InitializeComponent();
        }

        private void OnResetButtonClick(Object sender, RoutedEventArgs e)
        {
            ResetPasswordRequested?.Invoke();
        }

        private void OnLogInButtonClick(object sender, RoutedEventArgs e)
        {
            // Just work if its successfully loged in

            if (true)
            {
                LogInRequested?.Invoke();
            }
        }

        private void OnCreateButtonClick(object sender, RoutedEventArgs e)
        {
            CreateAccountRequested?.Invoke();
        }
    }
}
