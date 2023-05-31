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
    private SplittingPage_ViewModel _SplittingPageViewModel;
    private BubbleOrderPage_ViewModel _BubblePageViewModel;
    private Intersection_ViewModel _intersectionViewModel;
    private Union_ViewModel _UnionViewModel;
    private Swap_ViewModel _SwapViewModel;
    private MinSelection_ViewModel _MinSelectionViewModel;

    public AppShell(MainViewModel mainViewModel)
    {
		InitializeComponent();

		_mainViewModel = mainViewModel;
		_sumPageViewModel = new SumPage_ViewModel();
		_maxSelectionViewModel = new MaxSelection_ViewModel();
		_copyPageViewModel = new CopyPage_ViewModel();
		_SelectionPageViewModel = new SelectionPage_ViewModel();
        _SplittingPageViewModel = new SplittingPage_ViewModel();
        _BubblePageViewModel = new BubbleOrderPage_ViewModel();
		_intersectionViewModel = new Intersection_ViewModel();
		_UnionViewModel = new Union_ViewModel();
		_SwapViewModel = new Swap_ViewModel() ;
		_MinSelectionViewModel = new MinSelection_ViewModel();

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
            case "Splitting":
                Splitting_Clicked();
                break;
            case "Bubble":
                Bubble_Clicked();
            case "Intersection": Intersection_Clicked();
                break;
            case "Union": Union_Clicked();
                break;
            case "Swap": Swap_Clicked();
                break;
            case "MinSelection": MinSelection_Clicked();
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
    private void Splitting_Clicked()
    {
        Navigation.PushAsync(new SplittingPage
        {
            BindingContext = _copyPageViewModel,
        });
    }
    private void Bubble_Clicked()
    {
        Navigation.PushAsync(new BubbleOrderPage
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
