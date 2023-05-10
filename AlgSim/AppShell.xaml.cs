using AlgSim.View;
using AlgSim.ViewModel;

namespace AlgSim;

public partial class AppShell : Shell

{

	private MainViewModel _mainViewModel;
	private SumPage_ViewModel _sumPageViewModel;
	private MaxSelection_ViewModel _maxSelectionViewModel;

	public AppShell(MainViewModel mainViewModel)
	{
		InitializeComponent();

		_mainViewModel = mainViewModel;
		_sumPageViewModel = new SumPage_ViewModel();
		_maxSelectionViewModel = new MaxSelection_ViewModel();

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
			case "MaxSelection": MaxSelection_Clicked();
				break;
			default: DisplayAlert("Hiányzó tétel", "A tétel még nem elérhető", "OK");
				break;
        }
	}

    private void Sum_Clicked()
	{
		Navigation.PushAsync(new Sum_Page
		{
			BindingContext = _sumPageViewModel,
		});
	}

    private void Decision_Clicked()
    {
		
    }

	private void MaxSelection_Clicked()
	{
		Navigation.PushAsync(new MaxSelection_Page 
		{ 
			BindingContext = _maxSelectionViewModel, 
		});
	}
}
