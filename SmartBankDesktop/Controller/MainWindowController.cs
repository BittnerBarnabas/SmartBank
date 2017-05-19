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

        public void ShowView()
        {
            _mainWindow.Show();
        }
    }
}