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
            AccountDetailsGroupBox.Visibility = Visibility.Hidden;
        }

        public event Action<BankUser> CurrentUserChanged;

        public event Action<Transaction> ExecuteTransaction;

        private void UserNameComboBoxSelectionChanged(object sender,
            SelectionChangedEventArgs e)
        {
            var s = sender as ComboBox;
            CurrentUserChanged?.Invoke(s.SelectedItem as BankUser);
        }

        private void AccountSelectionButtonClick(object sender, RoutedEventArgs e)
        {
            SelectedAccountNumberLabel.Content = AccountSelectorComboBox.Text;
            AccountDetailsGroupBox.Visibility = Visibility.Visible;
        }

        private void ExecuteButtonClick(object sender, RoutedEventArgs e)
        {
            if (MoneyOutRadioButton.IsChecked.Value)
            {
                ExecuteTransaction?.Invoke(new Transaction
                {
                    Amount = int.Parse(AmountTextBox.Text),
                    TransactionDateTime = DateTime.Now,
                    RecipientAccountNumber = 0,
                    RecipientUserName = "Bank employee",
                    SourceAccountNumber =
                        int.Parse(SelectedAccountNumberLabel.Content.ToString())
                });
            }
            else if (MoneyInRadioButton.IsChecked.Value)
            {
                ExecuteTransaction?.Invoke(new Transaction
                {
                    Amount = int.Parse(AmountTextBox.Text),
                    TransactionDateTime = DateTime.Now,
                    RecipientAccountNumber =
                        int.Parse(SelectedAccountNumberLabel.Content.ToString()),
                    RecipientUserName = "Bank employee",
                    SourceAccountNumber = 0
                });
            }
            else if (TransactionRadioButton.IsChecked.Value)
            {
                ExecuteTransaction?.Invoke(new Transaction
                {
                    Amount = int.Parse(AmountTextBox.Text),
                    TransactionDateTime = DateTime.Now,
                    SourceAccountNumber =
                        int.Parse(SelectedAccountNumberLabel.Content.ToString()),
                    RecipientAccountNumber = int.Parse(AccountNumberTextBox.Text),
                    RecipientUserName = AccountOwnerTextBox.Text
                });
            }
            else if (LockAccountRadioButton.IsChecked.Value)
            {
                if (((BankAccount)AccountSelectorComboBox.SelectedItem).IsLocked)
                    if (MessageBox.Show("Unlock/Lock account",
                            "Account is Locked, are you sure you want to unlock it?",
                            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                    }
            }
        }
    }
}