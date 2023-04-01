using AlgSim.View;
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
		_mainViewModel.fillWithRandomNumbersClicked += new EventHandler(fillWithRandomNumbers_Clicked);

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

    private void fillWithRandomNumbers_Clicked(Object? sender, EventArgs e)
    {
		
    }

    private void Sum_Clicked()
	{
		Navigation.PushAsync(new Sum_Page
		{
			BindingContext = _mainViewModel,
		});
	}

    private void Decision_Clicked()
    {
		
    }
}
