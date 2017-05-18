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
        }

        public event Action<string, string> LogInButtonClickedEvent;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogInButtonClickedEvent?.Invoke(UserNameTextBox.Text, PasswordTextBox.Text);
        }
    }
}