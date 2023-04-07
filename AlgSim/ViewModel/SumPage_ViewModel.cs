using System.Collections.ObjectModel;
using AlgSim.ViewModel;

namespace AlgSim.View;

public class SumPage_ViewModel : ViewModelBase
{
    public DelegateCommand fillWithRandomNumbers { get; private set; }
    
    public ObservableCollection<int> numbers { get; set; } = new ObservableCollection<int>()
    {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
    };

    public SumPage_ViewModel()
	{
        fillWithRandomNumbers = new DelegateCommand(parameter => randomNumbersToFields());
        
    }

    private void randomNumbersToFields()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i] = new Random().Next(0, 100);
        }
    }
}