using SmartBankDesktop.View;

namespace SmartBankDesktop.Controller
{
    internal class MainWindowController : IController
    {
        private readonly MainWindow _mainWindow;

        public MainWindowController(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void ShowView()
        {
            _mainWindow.Show();
        }
    }
}