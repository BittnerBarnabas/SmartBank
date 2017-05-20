using System;
using System.Windows;
using System.Windows.Controls;
using SmartBankDesktop.Model;

namespace SmartBankDesktop.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public event Action<BankUser> CurrentUserChanged;

        private void UserNameComboBoxSelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            var s = sender as ComboBox;
            CurrentUserChanged?.Invoke(s.SelectedItem as BankUser);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}