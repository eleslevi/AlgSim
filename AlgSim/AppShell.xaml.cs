using AlgSim.View;
using AlgSim.ViewModel;

namespace AlgSim;

public partial class AppShell : Shell

{

	private MainViewModel _mainViewModel;
	private SumPage_ViewModel _sumPageViewModel;
	private MaxSelection_ViewModel _maxSelectionViewModel;
<<<<<<< Updated upstream
	private CopyPage_ViewModel _copyPageViewModel;
=======
    private Intersection_ViewModel _intersectionViewModel;
    private Union_ViewModel _UnionViewModel;
    private Swap_ViewModel _SwapViewModel;
    private MinSelection_ViewModel _MinSelectionViewModel;
>>>>>>> Stashed changes

	{
		InitializeComponent();

		_mainViewModel = mainViewModel;
		_sumPageViewModel = new SumPage_ViewModel();
		_maxSelectionViewModel = new MaxSelection_ViewModel();
<<<<<<< Updated upstream
		_copyPageViewModel = new CopyPage_ViewModel();
=======
		_intersectionViewModel = new Intersection_ViewModel();
		_UnionViewModel = new Union_ViewModel();
		_SwapViewModel = new Swap_ViewModel() ;
		_MinSelectionViewModel = new MinSelection_ViewModel();
>>>>>>> Stashed changes


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
<<<<<<< Updated upstream
			case "Copy": Copy_Clicked();
				break;
			default: DisplayAlert("Hiányzó tétel", "A tétel még nem elérhető", "OK");
=======
            case "Intersection": Intersection_Clicked();
                break;
            case "Union": Union_Clicked();
                break;
            case "Swap": Swap_Clicked();
                break;
            case "MinSelection": MinSelection_Clicked();
                break;
            default: DisplayAlert("Hiányzó tétel", "A tétel még nem elérhető", "OK");
>>>>>>> Stashed changes
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

	private void Intersection_Clicked()
	{
        Navigation.PushAsync(new Intersection_Page
        {
            BindingContext = _intersectionViewModel,
        });
    }

    private void Union_Clicked()
    {
        Navigation.PushAsync(new Union_Page
        {
            BindingContext = _UnionViewModel,
        });
    }

    private void Swap_Clicked()
    {
        Navigation.PushAsync(new Swap_Page
        {
            BindingContext = _SwapViewModel,
        });
    }

    private void MinSelection_Clicked()
    {
        Navigation.PushAsync(new MinSelection_Page
        {
            BindingContext = _MinSelectionViewModel,
        });
    }
}
