using AlgSim.View;
using AlgSim.ViewModel;

namespace AlgSim;

public partial class AppShell : Shell

{

	private MainViewModel _mainViewModel;
	private SumPage_ViewModel _sumPageViewModel;
	private MaxSelection_ViewModel _maxSelectionViewModel;
	private CopyPage_ViewModel _copyPageViewModel;
	private SelectionPage_ViewModel _SelectionPageViewModel;

	public AppShell(MainViewModel mainViewModel)
	{
		InitializeComponent();

		_mainViewModel = mainViewModel;
		_sumPageViewModel = new SumPage_ViewModel();
		_maxSelectionViewModel = new MaxSelection_ViewModel();
		_copyPageViewModel = new CopyPage_ViewModel();
		_SelectionPageViewModel = new SelectionPage_ViewModel();
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
			case "Copy": Copy_Clicked();
				break;
			case "Seletcion":Selection_Clicked();
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
	private void Copy_Clicked()
    {
        Navigation.PushAsync(new CopyPage
        {
            BindingContext = _copyPageViewModel,
        });
    }
	private void Selection_Clicked()
	{
		Navigation.PushAsync(new SelectionPage
		{
			BindingContext = _SelectionPageViewModel,
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
