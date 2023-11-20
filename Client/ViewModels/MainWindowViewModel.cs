using Client.Views;
namespace Client.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _KlientControl = new KlientControl();
            _KlientControl.DataContext = new KlientViewModel();
        }

        public KlientControl _KlientControl { get; set; }
    }
}