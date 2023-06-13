using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgSim.ViewModel;

namespace AlgSim.View
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
    };

        public ObservableCollection<double> result { get; set; } = new ObservableCollection<double>()
    {
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
    };

        public ObservableCollection<String> resultBackgroundColors { get; set; } = new ObservableCollection<String>()
    {
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

        public static int selectedStatement = 0;
        private bool shouldCopy = false;

        public static int userValue = 0;

        public int count = -1;

        public static String Statement = "";

        public ObservableCollection<String> Statements { get; set; } = new ObservableCollection<String>()
        {
            "Kisebb",
            "Nagyobb",
            "Páratlan",
            "Páros"
        };
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
                        backgroundColors[sim_cycle_iterator] = selectedBC;
                        resultBackgroundColors[count + 1] = selectedBC;
                        if (sim_cycle_iterator < numbers.Count)
                        {
                            int item = Convert.ToInt32(numbers[sim_cycle_iterator]);
                            if (Statement == Statements[0])
                            {
                                if (item < userValue)
                                {
                                    current_cycle = Cycle.Increment;
                                    shouldCopy = true;
                                }
                                else
                                {
                                    current_cycle = Cycle.EndIf;
                                }
                            }
                            else if (Statement == Statements[1])
                            {
                                if (item > userValue)
                                {
                                    current_cycle = Cycle.Increment;
                                    shouldCopy = true;
                                }
                                else
                                {
                                    current_cycle = Cycle.EndIf;
                                }
                            }
                            else if (Statement == Statements[2])
                            {
                                if (item % 2 == 1)
                                {
                                    current_cycle = Cycle.Increment;
                                    shouldCopy = true;
                                }
                                else
                                {
                                    current_cycle = Cycle.EndIf;
                                }
                            }
                            else if (Statement == Statements[3])
                            {
                                if (item % 2 == 0)
                                {
                                    current_cycle = Cycle.Increment;
                                    shouldCopy = true;
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
                        if (shouldCopy)
                        {
                            current_cycle = Cycle.Copy;
                            count++;
                        }
                        else
                        {
                            current_cycle = Cycle.EndIf;
                        }
                        break;
                    case Cycle.Copy:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndIf;
                        if (shouldCopy)
                        {
                            result[count] = numbers[sim_cycle_iterator];
                        }
                        break;
                    case Cycle.EndIf:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndCycle;
                        if (shouldCopy)
                        {
                            shouldCopy = false;
                            resultBackgroundColors[count] = whiteBC;
                        }
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
            OnPropertyChanged(nameof(resultBackgroundColors));
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
                Statement = Statements[0];
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] = 0;
                }
                sim_cycle_iterator = 0;
                userValue = 0;
                count = 0;
                OnPropertyChanged(nameof(backgroundColors));
                OnPropertyChanged(nameof(taskBackgroundColors));
                OnPropertyChanged(nameof(result));
            }
        }
    }
}
