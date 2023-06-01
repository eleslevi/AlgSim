using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlgSim.ViewModel
{
    public class MegszamolasPage_ViewModel : ViewModelBase
    {
        public DelegateCommand FillWithRandomNumbersCommand { get; private set; }
        public DelegateCommand ResetSimulationCommand { get; private set; }
        public DelegateCommand StepSimulationCommand { get; private set; }

        public static int userValue = 0;
        public static int selectedStatement = 0;
        public static String Statement = "";

        public ObservableCollection<String> Statements { get; set; } = new ObservableCollection<String>()
        {
            "Páros szám",
            "Páratlan szám",
            "Kisebb",
            "Nagyobb",
        };

        private bool isSimulationRunning = false;
        private int simulationCycleIterator = 0;

        private String whiteBC = "White";
        private String selectedBC = "LightBlue";

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
            0,
        };
        public ObservableCollection<String> BackgroundColors { get; set; } = new ObservableCollection<String>()
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
        public ObservableCollection<Color> TaskBackgroundColors { get; set; } = new ObservableCollection<Color>()
        {
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
        };

        public ObservableCollection<int> result { get; set; } = new ObservableCollection<int>()
        {
            0,
        };

        private enum Cycle
        {
            StartTask,
            InitOccurrences,
            StepCycle,
            CountOccurrences,
            EndCycle,
            EndTask
        }

        private Cycle currentCycle = Cycle.StartTask;

        public MegszamolasPage_ViewModel()
        {
            FillWithRandomNumbersCommand = new DelegateCommand(parameter => FillWithRandomNumbers());
            ResetSimulationCommand = new DelegateCommand(parameter => ResetSimulation());
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
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.InitOccurrences;
                        break;
                    case Cycle.InitOccurrences:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        BackgroundColors[simulationCycleIterator] = selectedBC;
                        currentCycle = Cycle.CountOccurrences;
                        break;
                    case Cycle.CountOccurrences:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.EndCycle;
                        if(Statement == "Páros szám" && numbers[simulationCycleIterator] % 2 == 0 || Statement == "Páratlan szám" && numbers[simulationCycleIterator] % 2 == 1 || Statement == "Kisebb" && numbers[simulationCycleIterator] < userValue || Statement == "Nagyobb" && numbers[simulationCycleIterator] > userValue)
                        {
                            result[0]++;
                        }
                        break;
                    case Cycle.EndCycle:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        simulationCycleIterator++;
                        if (simulationCycleIterator < numbers.Count)
                        {
                            currentCycle = Cycle.StepCycle;
                        }
                        else
                        {
                            currentCycle = Cycle.EndTask;
                        }
                        BackgroundColors[simulationCycleIterator - 1] = whiteBC;
                        break;
                    case Cycle.EndTask:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        break;
                }
            }
            TaskBackgroundColors[(int)currentCycle] = Colors.Red;
            OnPropertyChanged(nameof(TaskBackgroundColors));
            OnPropertyChanged(nameof(BackgroundColors));
            OnPropertyChanged(nameof(result));
        }

        private void ResetSimulation()
        {
            if (isSimulationRunning)
            {
                for (int i = 0; i < BackgroundColors.Count; i++)
                {
                    numbers[i] = 0;
                    BackgroundColors[i] = whiteBC;
                }
                for (int i = 0; i < TaskBackgroundColors.Count; i++)
                {
                    TaskBackgroundColors[i] = Colors.Black;
                }
                simulationCycleIterator = 0;
                currentCycle = Cycle.StartTask;
                result[0] = 0;
                OnPropertyChanged(nameof(result));
                OnPropertyChanged(nameof(BackgroundColors));
                OnPropertyChanged(nameof(TaskBackgroundColors));
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
