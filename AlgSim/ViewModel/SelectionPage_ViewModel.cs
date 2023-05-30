using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSim.ViewModel
{
    class SelectionPage_ViewModel:ViewModelBase 
    {
        public DelegateCommand fillWithRandomNumbers { get; private set; }
        public DelegateCommand resetNumbers { get; private set; }
        public DelegateCommand stepSim { get; private set; }

        private Boolean isSimulationRunning = false;

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
            InitCount,
            StepCycle,
            StartIf,
            Increment,
            Copy,
            EndIf,
            EndCycle,
            End_Task
        }

        public int value = 0;
        public int count = 0;

        private enum Statement
        {
            kisebb,nagyobb,páratlan,páros
        }
        private Statement statement = Statement.kisebb;
            

        private Cycle current_cycle = Cycle.Start_Task;

        public SelectionPage_ViewModel()
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
                        current_cycle = Cycle.InitCount;
                        break;
                    case Cycle.InitCount:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        if (sim_cycle_iterator < numbers.Count)
                        {
                            current_cycle = Cycle.StartIf;
                        }
                        else
                        {
                            current_cycle = Cycle.End_Task;
                        }
                        break;
                    case Cycle.StartIf:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        if (sim_cycle_iterator < numbers.Count)
                        {
                            var item = result[sim_cycle_iterator];
                            if (statement == Statement.kisebb)
                            {
                                if (item < value)
                                {
                                    current_cycle = Cycle.Increment;
                                }
                                else
                                {
                                    current_cycle = Cycle.EndIf;
                                }
                            }
                            else if (statement == Statement.nagyobb)
                            {
                                if (item > value)
                                {
                                    current_cycle = Cycle.Increment;
                                }
                                else
                                {
                                    current_cycle = Cycle.EndIf;
                                }
                            }
                            else if (statement == Statement.páratlan)
                            {
                                if (item % 2 == 1)
                                {
                                    current_cycle = Cycle.Increment;
                                }
                                else
                                {
                                    current_cycle = Cycle.EndIf;
                                }
                            }
                            else if (statement == Statement.páros)
                            {
                                if (item % 2 == 0)
                                {
                                    current_cycle = Cycle.Increment;
                                }
                                else
                                {
                                    current_cycle = Cycle.EndIf;
                                }
                            }
                        }
                        else
                        {
                            current_cycle = Cycle.EndCycle;
                        }
                        break;
                    case Cycle.Increment:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.Copy;
                        count++;
                        break;
                    case Cycle.Copy:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndIf;
                        backgroundColors[sim_cycle_iterator] = selectedBC;
                        break;
                    case Cycle.EndIf:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndCycle;
                        result[sim_cycle_iterator] = numbers[sim_cycle_iterator];
                        break;
                    case Cycle.EndCycle:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.StepCycle;
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
                statement = Statement.kisebb;
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] = 0;
                }
                sim_cycle_iterator = 0;
                value = 0;
                count = 0;
                OnPropertyChanged(nameof(backgroundColors));
                OnPropertyChanged(nameof(taskBackgroundColors));
                OnPropertyChanged(nameof(result));
            }
        }
    }
}
