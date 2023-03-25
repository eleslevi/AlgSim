using AlgSim.ViewModel;

namespace AlgSim;

public partial class App : Application
{

	private readonly AppShell _appShell;
	private readonly MainViewModel _mainViewModel;
	public App()
	{
		InitializeComponent();

		_mainViewModel = new MainViewModel();

		_appShell = new AppShell(_mainViewModel)
		{
			BindingContext = _mainViewModel
		};

		MainPage = _appShell;
	}
}
