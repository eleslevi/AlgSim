using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSim.ViewModel
{
    class SplittingPage_ViewModel : ViewModelBase
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

        public ObservableCollection<double> resultX { get; set; } = new ObservableCollection<double>()
    {
        0,
        0,
        0,
        0,
        0,
    };
        public ObservableCollection<double> resultY { get; set; } = new ObservableCollection<double>()
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
        public ObservableCollection<String> backgroundColorsX { get; set; } = new ObservableCollection<String>()
    {
        "White",
        "White",
        "White",
        "White",
        "White",
    };
        public ObservableCollection<String> backgroundColorsY { get; set; } = new ObservableCollection<String>()
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
            Initiation,
            StepCycle,
            StartIf,
            IncrementX,
            CopyX,
            Else,
            IncrementY,
            CopyY,
            EndIf,
            EndCycle,
            End_Task
        }

        public int countX = -1;
        public int countY = -1;

        public static int selectedStatement = 0;
        public static int userValue = 0;
        public static String Statement = "Kisebb";
        public ObservableCollection<String> Statements { get; set; } = new ObservableCollection<String>()
        {
            "Kisebb",
            "Nagyobb",
            "Páratlan",
            "Páros"
        };
        private Cycle current_cycle = Cycle.Start_Task;

        public SplittingPage_ViewModel()
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
                        current_cycle = Cycle.Initiation;
                        break;
                    case Cycle.Initiation:
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
                            int item = Convert.ToInt32(numbers[sim_cycle_iterator]);
                            if (Statement == Statements[0])
                            {
                                if (item < userValue)
                                {
                                    current_cycle = Cycle.IncrementX;
                                }
                                else
                                {
                                    current_cycle = Cycle.Else;
                                }
                            }
                            else if (Statement == Statements[1])
                            {
                                if (item > userValue)
                                {
                                    current_cycle = Cycle.IncrementX;
                                }
                                else
                                {
                                    current_cycle = Cycle.Else;
                                }
                            }
                            else if (Statement == Statements[2])
                            {
                                if (item % 2 == 1)
                                {
                                    current_cycle = Cycle.IncrementX;
                                }
                                else
                                {
                                    current_cycle = Cycle.Else;
                                }
                            }
                            else if (Statement == Statements[3])
                            {
                                if (item % 2 == 0)
                                {
                                    current_cycle = Cycle.IncrementX;
                                }
                                else
                                {
                                    current_cycle = Cycle.Else;
                                }
                            }
                        }
                        else
                        {
                            current_cycle = Cycle.EndCycle;
                        }
                        break;
                    case Cycle.IncrementX:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.CopyX;
                        countX++;
                        break;
                    case Cycle.CopyX:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndIf;
                        backgroundColors[sim_cycle_iterator] = selectedBC;
                        backgroundColorsX[countX] = selectedBC;
                        resultX[countX] = numbers[sim_cycle_iterator];
                        break;
                    case Cycle.Else:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.IncrementY;
                        break;
                    case Cycle.IncrementY:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.CopyY;
                        countY++;
                        break;
                    case Cycle.CopyY:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndIf;
                        backgroundColors[sim_cycle_iterator] = selectedBC;
                        backgroundColorsY[countY] = selectedBC;
                        resultY[countY] = numbers[sim_cycle_iterator];
                        break;
                    case Cycle.EndIf:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndCycle;
                        break;
                    case Cycle.EndCycle:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.StepCycle;
                        backgroundColors[sim_cycle_iterator] = whiteBC;
                        if (countX >= 0)
                        {
                            backgroundColorsX[countX] = whiteBC;
                        }
                        if (countY >= 0)
                        {
                            backgroundColorsY[countY] = whiteBC;
                        }
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
            OnPropertyChanged(nameof(backgroundColorsX));
            OnPropertyChanged(nameof(backgroundColorsY));
            OnPropertyChanged(nameof(resultX));
            OnPropertyChanged(nameof(resultY));
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
                for (int i = 0; i < resultX.Count; i++)
                {
                    resultX[i] = 0;
                }
                for (int i = 0; i < resultY.Count; i++)
                {
                    resultY[i] = 0;
                }
                sim_cycle_iterator = 0;
                userValue = 0;
                countX = -1;
                countX = -1;
                OnPropertyChanged(nameof(backgroundColors));
                OnPropertyChanged(nameof(taskBackgroundColors));
                OnPropertyChanged(nameof(resultX));
                OnPropertyChanged(nameof(resultY));
            }
        }
    }
}
