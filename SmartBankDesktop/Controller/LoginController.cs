using SmartBankDesktop.Model;
using SmartBankDesktop.View;

namespace SmartBankDesktop.Controller
{
    internal class LoginController : IController
    {
        private readonly LoginWindow _loginWindow;
        private readonly LoginModel _loginModel;

        public LoginController(LoginWindow loginWindow, LoginModel loginModel)
        {
            _loginWindow = loginWindow;
            _loginModel = loginModel;

            _loginWindow.LogInButtonClickedEvent +=
                (userName, password) => _loginModel.LogIn(userName, password);
        }

        public void ShowView()
        {
            _loginWindow.Show();
        }
    }
}