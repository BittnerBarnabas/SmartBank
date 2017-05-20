using System.Collections.Generic;
using SmartBankDesktop.Model;
using SmartBankDesktop.View;

namespace SmartBankDesktop.Controller
{
    internal class MainWindowController : AbstractController, IController
    {
        private readonly MainModel _mainModel;
        private readonly MainWindow _mainWindow;

        public MainWindowController(MainWindow mainWindow, MainModel mainModel)
        {
            _mainWindow = mainWindow;
            _mainModel = mainModel;
            _mainWindow.DataContext = this;
            _mainWindow.CurrentUserChanged +=
                user => SelectedUser = user;
            _mainWindow.ExecuteTransaction +=
                transaction => _mainModel.ExecuteTransaction(transaction);
        }

        public string LoggedInUserName
        {
            get { return _mainModel.LoggedInUserName; }
            set
            {
                _mainModel.LoggedInUserName = value;
                OnPropertyChanged(nameof(LoggedInUserName));
            }
        }

        public IEnumerable<BankUser> BankUsers
        {
            get { return _mainModel.BankUsers; }
            set
            {
                _mainModel.BankUsers = value;
                OnPropertyChanged(nameof(BankUsers));
            }
        }

        public BankUser SelectedUser
        {
            get { return _mainModel.SelectedUser; }
            set
            {
                _mainModel.SelectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public void ShowView()
        {
            _mainModel.PopulateDataForDispay();
            _mainWindow.Show();

            BankUsers = _mainModel.BankUsers;
        }
    }
}