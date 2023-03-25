using AlgSim.ViewModel;

namespace AlgSim;

public partial class AppShell : Shell

{

	private MainViewModel _mainViewModel;

	public AppShell(MainViewModel mainViewModel)
	{
		InitializeComponent();

		_mainViewModel = mainViewModel;

		_mainViewModel.MenuClicked += new EventHandler(ViewModel_MenuClicked);

	}

	private void ViewModel_MenuClicked(Object? sender, EventArgs e)
	{
		DisplayAlert("Próba", "Működik a parancs kiírása", "OK");
	}
}
