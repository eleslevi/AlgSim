using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace AlgSim.ViewModel
{
    public class EldontesPage_ViewModel : ViewModelBase
    {
        public DelegateCommand FillWithRandomNumbersCommand { get; private set; }
        public DelegateCommand ResetNumbersCommand { get; private set; }
        public DelegateCommand StepSimulationCommand { get; private set; }

        public static int userValue = 0;
        public static int selectedStatement = 0;
        public static String Statement = "";

        public ObservableCollection<String> Statements { get; set; } = new ObservableCollection<String>()
        {
            "Páros szám",
            "Páratlan szám",
            "Konkrét érték",
        };

        private bool isSimulationRunning = false;
        private int simulationCycleIterator = 0;

        private String whiteBC = "White";
        private String selectedBC = "LightBlue";

        public ObservableCollection<String> currentEldontes { get; } = new ObservableCollection<String> { "" };
        public ObservableCollection<int> numbers { get; } = new ObservableCollection<int>()
        {
            0,
            0,
            0,
            0,
            0,
        };
        public ObservableCollection<String> backgroundColors { get; } = new ObservableCollection<String>()
        {
            "White",
            "White",
            "White",
            "White",
            "White",
        };

        public ObservableCollection<Color> TaskbackgroundColors { get; } = new ObservableCollection<Color>()
        {
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
        };

        private enum Cycle
        {
            StartTask,
            InitSum,
            StepCycle,
            CheckNum,
            EndCycle,
            Check,
            EndTask
        }

        private Cycle currentCycle = Cycle.StartTask;

        public EldontesPage_ViewModel()
        {
            FillWithRandomNumbersCommand = new DelegateCommand(parameter => FillWithRandomNumbers());
            ResetNumbersCommand = new DelegateCommand(parameter => ResetSimulation());
            StepSimulationCommand = new DelegateCommand(parameter => StepSimulation());
        }

        private void StepSimulation()
        {
            if (!isSimulationRunning)
            {
                isSimulationRunning = true;
            }
            else
            {
                switch (currentCycle)
                {
                    case Cycle.StartTask:
                        TaskbackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.InitSum;
                        break;
                    case Cycle.InitSum:
                        TaskbackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        TaskbackgroundColors[(int)currentCycle] = Colors.Black;
                        backgroundColors[simulationCycleIterator] = selectedBC;
                        if (simulationCycleIterator < numbers.Count)
                        {
                            currentCycle = Cycle.CheckNum;
                        }
                        else
                        {
                            currentCycle = Cycle.Check;
                        }
                        break;
                    case Cycle.CheckNum:
                        TaskbackgroundColors[(int)currentCycle] = Colors.Black;
                        if (Statement == "Páros szám" && numbers[simulationCycleIterator] % 2 == 0 || Statement == "Páratlan szám" && numbers[simulationCycleIterator] % 2 == 1 || Statement == "Konkrét érték" && numbers[simulationCycleIterator] == userValue)
                        {
                            currentCycle = Cycle.Check;
                        }
                        else
                        {
                            currentCycle = Cycle.EndCycle;
                        }
                        break;
                    case Cycle.EndCycle:
                        TaskbackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.StepCycle;
                        currentEldontes[0] += numbers[simulationCycleIterator];
                        backgroundColors[simulationCycleIterator] = whiteBC;
                        simulationCycleIterator++;
                        break;
                    case Cycle.Check:
                        TaskbackgroundColors[(int)currentCycle] = Colors.Black;
                        if (simulationCycleIterator < numbers.Count)
                        {
                            currentEldontes[0] = "Igen";
                        }
                        else
                        {
                            currentEldontes[0] = "Nem";
                        }
                        currentCycle = Cycle.EndTask;
                        break;
                    case Cycle.EndTask:
                        TaskbackgroundColors[(int)currentCycle] = Colors.Black;
                        break;
                }
            }
            TaskbackgroundColors[(int)currentCycle] = Colors.Red;
            OnPropertyChanged(nameof(TaskbackgroundColors));
            OnPropertyChanged(nameof(backgroundColors));
            OnPropertyChanged(nameof(currentEldontes));
        }

        private void ResetSimulation()
        {
            if (isSimulationRunning)
            {
                for (int i = 0; i < backgroundColors.Count; i++)
                {
                    numbers[i] = 0;
                    backgroundColors[i] = whiteBC;
                }
                for (int i = 0;i < TaskbackgroundColors.Count; i++)
                {
                    TaskbackgroundColors[i] = Colors.Black;
                }
                currentCycle = Cycle.StartTask;
                simulationCycleIterator = 0;
                currentEldontes[0] = "";
                OnPropertyChanged(nameof(currentEldontes));
                OnPropertyChanged(nameof(TaskbackgroundColors));
                OnPropertyChanged(nameof(backgroundColors));
                OnPropertyChanged(nameof(currentEldontes));
                isSimulationRunning = false;
            }
        }

        private void FillWithRandomNumbers()
        {
            if (!isSimulationRunning)
            {
                numbers.Clear();
                for (int i = 0; i < 10; i++)
                {
                    numbers.Add(new Random().Next(0, 15));
                }
                OnPropertyChanged(nameof(numbers));
            }
        }
    }
}
