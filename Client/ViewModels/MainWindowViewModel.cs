using Client.Views;
namespace Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _KlientControl = new Client.Views.KlientControl();
            _KlientControl.DataContext = new KlientViewModel();
        }

        public Client.Views.KlientControl _KlientControl { get; set; }
    }
}