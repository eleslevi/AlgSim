using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSim.ViewModel
{
    class CopyPage_ViewModel:ViewModelBase
    {
        public DelegateCommand fillWithRandomNumbers { get; private set; }
        public DelegateCommand resetNumbers { get; private set; }
        public DelegateCommand stepSim { get; private set; }

        private Boolean isSimulationRunning = false;

        public bool Function = false;

        private int sim_cycle_iterator = 0;

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

        public ObservableCollection<double> result { get; set; } = new ObservableCollection<double>()
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

        public ObservableCollection<String> backgroundColors { get; set; } = new ObservableCollection<String>()
    {
        "White",
        "White",
        "White",
        "White",
        "White",
        "White",
        "White",
        "White",
        "White",
        "White",
    };

        public ObservableCollection<Color> taskBackgroundColors { get; set; } = new ObservableCollection<Color>()
    {
        Colors.Black,
        Colors.Black,
        Colors.Black,
        Colors.Black,
        Colors.Black,
    };
        private String whiteBC = "White";
        private String blackBC = "Black";
        private String selectedBC = "LightBlue";

        private enum Cycle
        {
            Start_Task,
            StepCycle,
            Copy,
            EndCycle,
            End_Task
        }

        private Cycle current_cycle = Cycle.Start_Task;

        public CopyPage_ViewModel()
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
                    case Cycle.Start_Task:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        if (sim_cycle_iterator < numbers.Count)
                        {
                            current_cycle = Cycle.Copy;
                        }
                        else
                        {
                            current_cycle = Cycle.End_Task;
                        }
                        break;
                    case Cycle.Copy:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndCycle;
                        backgroundColors[sim_cycle_iterator] = selectedBC;
                        break;
                    case Cycle.EndCycle:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.StepCycle;
                        //result[sim_cycle_iterator] = numbers[sim_cycle_iterator];
                        if (Function)
                        {
                            result[sim_cycle_iterator] = Math.Pow(numbers[sim_cycle_iterator], 2);
                        }
                        else
                        {
                            result[sim_cycle_iterator] = Math.Sqrt(numbers[sim_cycle_iterator]);
                        }
                        backgroundColors[sim_cycle_iterator] = whiteBC;
                        sim_cycle_iterator++;
                        break;
                    case Cycle.End_Task:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        break;
                }
            }
            taskBackgroundColors[(int)current_cycle] = Colors.Red;
            OnPropertyChanged(nameof(taskBackgroundColors));
            OnPropertyChanged(nameof(backgroundColors));
            OnPropertyChanged(nameof(result));
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
        private void resetSimulation()
        {
            if (isSimulationRunning)
            {
                for (int i = 0; i < backgroundColors.Count; i++)
                {
                    backgroundColors[i] = whiteBC;
                }
                isSimulationRunning = false;
                taskBackgroundColors[(int)current_cycle] = Colors.Black;
                current_cycle = Cycle.Start_Task;
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] = 0;
                }
                sim_cycle_iterator = 0;
                OnPropertyChanged(nameof(backgroundColors));
                OnPropertyChanged(nameof(taskBackgroundColors));
                OnPropertyChanged(nameof(result));
            }

        }
    }  
}
