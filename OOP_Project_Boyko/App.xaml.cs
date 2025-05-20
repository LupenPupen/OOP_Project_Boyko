using OOP_Project_Boyko.Data;
using System.Windows;
using System.Windows.Threading;

namespace OOP_Project_Boyko
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DataStore.LoadData();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            DataStore.SaveData();
        }
    }
}