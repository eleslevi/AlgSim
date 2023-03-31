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
		switch (sender.ToString())
		{
            case "Sum": Sum_Clicked();
				break;
			case "Decision": Decision_Clicked();
				break;
			default: DisplayAlert("Hiányzó tétel", "A tétel még nem elérhető", "OK");
				break;
        }
	}

	private void Sum_Clicked()
	{
		
	}

    private void Decision_Clicked()
    {

    }
}
