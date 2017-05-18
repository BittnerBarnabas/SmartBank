﻿using System.Windows;
using Serilog;
using SmartBankDesktop.Controller;
using SmartBankDesktop.Model;
using SmartBankDesktop.View;

namespace SmartBankDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private LoginController _loginController;
        private MainWindowController _mainWindowController;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace(
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}")
                .CreateLogger();

            _loginController = new LoginController(new LoginWindow(), new LoginModel());
            _mainWindowController = new MainWindowController(new MainWindow());

            _loginController.SuccesfulLoginAttempt +=
                isSuccess =>
                {
                    if (isSuccess)
                        _mainWindowController.ShowView();
                };

            _loginController.ShowView();
        }
    }
}