using DevEmporium.Presentation.Views;
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

namespace DevEmporium.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            loginView.ResetPasswordRequested += OnResetPasswordRequested;
            loginView.LogInRequested += OnLogedInRequested;
            loginView.CreateAccountRequested += OnCreateAccountRequested;
            SignUpView.ReturnToLoginRequested += OnReturnToLoginRequested;
            resetPassword.ReturnToLoginRequested += OnReturnToLoginRequested2;

        }

        private void OnReturnToLoginRequested()
        {
            if(SignUpView.Visibility == Visibility.Visible)
            {
                SignUpView.Visibility = Visibility.Collapsed;
                loginView.Visibility = Visibility.Visible;
            }
        }

        private void OnReturnToLoginRequested2()
        {
            if (resetPassword.Visibility == Visibility.Visible)
            {
                resetPassword.Visibility = Visibility.Collapsed;
                loginView.Visibility = Visibility.Visible;
            }
        }

        private void OnCreateAccountRequested()
        {
            if (loginView.Visibility == Visibility.Visible)
            {
                loginView.Visibility = Visibility.Collapsed;
                SignUpView.Visibility = Visibility.Visible;
            }
        }

        private void OnLogedInRequested()
        {
            // Create the new window
            StoreView storeView = new StoreView();

            // Show the window
            storeView.Show();
            // Close the window

            Close();

        }

        private void OnResetPasswordRequested()
        {
            if (loginView.Visibility == Visibility.Visible)
            {
                loginView.Visibility = Visibility.Collapsed;
                resetPassword.Visibility = Visibility.Visible;
            }
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
