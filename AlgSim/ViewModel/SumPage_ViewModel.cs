using System.Collections.ObjectModel;
using AlgSim.ViewModel;

namespace AlgSim.View;

public class SumPage_ViewModel : ViewModelBase
{
    public DelegateCommand fillWithRandomNumbers { get; private set; }
    public DelegateCommand resetNumbers { get; private set; }
    public DelegateCommand stepSim { get; private set; }

    private Boolean isSimulationRunning = false;

    private int sim_cycle_iterator = 0;
    
    private Color whiteBC = Colors.White;
    private Color selectedBC = Colors.LightBlue;

    public ObservableCollection<int> currentSum { get; set; } = new ObservableCollection<int> { 0 };
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
    public ObservableCollection<Color> backgroundColors { get; set; } = new ObservableCollection<Color>()
    {
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
    };
    public ObservableCollection<Color> taskBackgroundColors { get; set; } = new ObservableCollection<Color>()
    {
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
    };

    private enum cycle
    {
        start_task,
        init_sum,
        step_cycle,
        add_numbers,
        end_cycle,
        end_task
    }

    private cycle current_cycle = cycle.start_task;

    public SumPage_ViewModel()
	{
        fillWithRandomNumbers = new DelegateCommand(parameter => randomNumbersToFields());
        resetNumbers = new DelegateCommand(parameter => resetSimulation());
        stepSim = new DelegateCommand(parametr => stepSimulation());
    }

    private void stepSimulation()
    {
        if (!isSimulationRunning)
        {
            isSimulationRunning = true;
        }
        else
        {
            switch (current_cycle)
            {
                case cycle.start_task:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    current_cycle = cycle.init_sum;
                    break;
                case cycle.init_sum:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    current_cycle = cycle.step_cycle;
                    break;
                case cycle.step_cycle:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    if (sim_cycle_iterator < numbers.Count)
                    {
                        current_cycle = cycle.add_numbers;
                    }
                    else
                    {
                        current_cycle = cycle.end_task;
                    }
                    break;
                case cycle.add_numbers:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    current_cycle = cycle.end_cycle;
                    backgroundColors[sim_cycle_iterator] = selectedBC;
                    break;
                case cycle.end_cycle:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    current_cycle = cycle.step_cycle;
                    currentSum[0] = currentSum[0] + numbers[sim_cycle_iterator];
                    backgroundColors[sim_cycle_iterator] = whiteBC;
                    sim_cycle_iterator++;
                    break;
                case cycle.end_task:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    break;
            }
        }
        taskBackgroundColors[(int)current_cycle] = Colors.Red;
        OnPropertyChanged(nameof(taskBackgroundColors));
        OnPropertyChanged(nameof(backgroundColors));
        OnPropertyChanged(nameof(currentSum));
    }

    private void resetSimulation()
    {
        if (isSimulationRunning)
        {
            for (int i = 0; i < backgroundColors.Count; i++)
            {
                backgroundColors[i] = whiteBC;
            }
            OnPropertyChanged(nameof(backgroundColors));
            isSimulationRunning = false;
        }
    }

    private void randomNumbersToFields()
    {
        if (!isSimulationRunning)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = new Random().Next(0, 15);
            }
            OnPropertyChanged(nameof(numbers));
        }
    }
}