using System.Windows;
using VideoStore.Presenter;
using VideoStore.Views;

namespace VideoStore.Startup
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var presenter = new MainPresenter();
            presenter.ShowLogin();
        }
    }
}
