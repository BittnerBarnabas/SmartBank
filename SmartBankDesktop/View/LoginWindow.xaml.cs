using System;
using System.Windows;

namespace SmartBankDesktop.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            errorLabel.Visibility = Visibility.Hidden;
        }

        public event Action<string, string> LogInButtonClickedEvent;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            errorLabel.Visibility = Visibility.Hidden;
            LogInButtonClickedEvent?.Invoke(UserNameTextBox.Text, PasswordTextBox.Password);
        }
    }
}