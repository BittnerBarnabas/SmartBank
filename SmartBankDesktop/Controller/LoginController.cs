using System;
using System.Windows;
using Serilog;
using SmartBankDesktop.Model;
using SmartBankDesktop.View;

namespace SmartBankDesktop.Controller
{
    internal class LoginController : IController
    {
        private readonly LoginModel _loginModel;
        private readonly LoginWindow _loginWindow;
        private readonly ILogger LOG = Log.ForContext<LoginController>();

        public LoginController(LoginWindow loginWindow, LoginModel loginModel)
        {
            _loginWindow = loginWindow;
            _loginModel = loginModel;

            _loginWindow.LogInButtonClickedEvent +=
                (userName, password) => _loginModel.LogIn(userName, password);

            _loginModel.LoginAttemptEvent += (employee, successFul) =>
            {
                if (successFul)
                {
                    LOG.Information("Succesful login with username: {userName}",
                        employee.UserName);
                    _loginWindow.Close();
                    SuccesfulLoginAttempt?.Invoke(true);
                }
                else
                {
                    LOG.Information("Login failed for username: {userName}",
                        employee.UserName);
                    _loginWindow.PasswordTextBox.Clear();
                    _loginWindow.UserNameTextBox.Clear();
                    _loginWindow.errorLabel.Visibility = Visibility.Visible;
                    SuccesfulLoginAttempt?.Invoke(false);
                }
            };
        }

        public void ShowView()
        {
            _loginWindow.Show();
        }

        public event Action<bool> SuccesfulLoginAttempt;
    }
}