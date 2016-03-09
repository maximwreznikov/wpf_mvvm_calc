﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CalculatorMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppBootstrapper appBootstrapper = new AppBootstrapper();
            appBootstrapper.Run();
            MainWindow window = new MainWindow();
            window.Content = appBootstrapper.CalculatorView;
            window.Show();
        }
    }
}
