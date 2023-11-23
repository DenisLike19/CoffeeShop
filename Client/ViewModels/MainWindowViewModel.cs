using Client.Views;
namespace Client.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public MainWindowViewModel() 
		{
			_KlientsUserControl = new KlientsUserControl();
			_KlientsUserControl.DataContext = new KlientsUserControlViewModel();
            _GoodsUserControl = new GoodsUserControl();
            _GoodsUserControl.DataContext = new GoodsUserControlViewModel();
        }

		public KlientsUserControl _KlientsUserControl { get; set; }
        public GoodsUserControl _GoodsUserControl { get; set; }
    }
}