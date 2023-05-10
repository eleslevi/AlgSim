using System.Collections.ObjectModel;
using System.ComponentModel.Design;

namespace AlgSim.ViewModel;

public class MaxSelection_ViewModel : ContentPage
{
    public DelegateCommand fillWithRandomNumbers { get; private set; }
    public DelegateCommand resetNumbers { get; private set; }
    public DelegateCommand stepSim { get; private set; }

    private Boolean isSimulationRunning = false;

    private int sim_cycle_iterator = 1;

    private Color whiteBC = Colors.White;
    private Color selectedBC = Colors.LightBlue;
    private Color maxBC = Colors.LightGreen;

    public ObservableCollection<int> max { get; set; } = new ObservableCollection<int> { 0, 0 };
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
        Colors.White,
    };

    private enum cycle
    {
        start_task,
        init_index,
        step_cycle,
        check_greater,
        set_new_max,
        end_cycle,
        end_task
    }

    private cycle current_cycle = cycle.start_task;

    public MaxSelection_ViewModel()
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
                    current_cycle = cycle.init_index;
                    backgroundColors[0] = maxBC;
                    max[0] = 0;
                    max[1] = numbers[0];
                    break;
                case cycle.init_index:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    current_cycle = cycle.step_cycle;
                    break;
                case cycle.step_cycle:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    if (sim_cycle_iterator < numbers.Count)
                    {
                        backgroundColors[sim_cycle_iterator] = selectedBC;
                        current_cycle = cycle.check_greater;
                    }
                    else
                    {
                        current_cycle = cycle.end_task;
                    }
                    break;
                case cycle.check_greater:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    if (numbers[sim_cycle_iterator] > numbers[max[0]])
                    {
                        current_cycle = cycle.set_new_max;
                    }
                    else
                    {
                        current_cycle = cycle.end_cycle;
                    }
                    break;
                case cycle.set_new_max:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    current_cycle = cycle.end_cycle;
                    backgroundColors[max[0]] = whiteBC;
                    backgroundColors[sim_cycle_iterator] = maxBC;
                    max[0] = sim_cycle_iterator;
                    max[1] = numbers[sim_cycle_iterator];
                    break;
                case cycle.end_cycle:
                    taskBackgroundColors[(int)current_cycle] = whiteBC;
                    if(sim_cycle_iterator != max[0])
                    {
                        backgroundColors[sim_cycle_iterator] = whiteBC;
                    }
                    current_cycle = cycle.step_cycle;
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
        OnPropertyChanged(nameof(max));
    }

    private void resetSimulation()
    {
        if (isSimulationRunning)
        {
            for (int i = 0; i < backgroundColors.Count; i++)
            {
                numbers[i] = 0;
                backgroundColors[i] = whiteBC;
            }
            for (int i = 0; i < taskBackgroundColors.Count; i++)
            {
                taskBackgroundColors[i] = whiteBC;
            }
            max[0] = 0;
            max[1] = 0;
            sim_cycle_iterator = 1;
            OnPropertyChanged(nameof(max));
            OnPropertyChanged(nameof(backgroundColors));
            OnPropertyChanged(nameof(taskBackgroundColors));
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