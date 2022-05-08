using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using assign3.NavState;
using assign3.ViewModels;
namespace assign3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationState navState = new NavigationState();

            navState.CurrentViewModel = new HomeViewModel(navState);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navState)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
