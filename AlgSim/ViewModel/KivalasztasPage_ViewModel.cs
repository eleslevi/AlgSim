using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlgSim.ViewModel
{
    public class KivalasztasPage_ViewModel : ViewModelBase
    {
        public DelegateCommand FillWithRandomNumbersCommand { get; }
        public DelegateCommand ResetSimulationCommand { get; }
        public DelegateCommand StepSimulationCommand { get; }

        private bool isSimulationRunning = false;
        private int simulationCycleIterator = 0;
        public static int userValue = -1;

        private String whiteBC = "White";
        private String selectedBC = "LightBlue";

        public ObservableCollection<int> numbers { get; set; } = new ObservableCollection<int>()
        {
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
        };
        public ObservableCollection<Color> TaskBackgroundColors { get; set; } = new ObservableCollection<Color>()
        {
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
        };

        public ObservableCollection<int> results { get; set; } = new ObservableCollection<int>()
        {
            -1,
        };

        private enum Cycle
        {
            StartTask,
            InitSelection,
            StepCycle,
            SelectNumber,
            EndCycle,
            S_i,
            EndTask
        }

        private Cycle currentCycle = Cycle.StartTask;

        public KivalasztasPage_ViewModel()
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
                        currentCycle = Cycle.InitSelection;
                        break;
                    case Cycle.InitSelection:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        if (simulationCycleIterator < numbers.Count)
                        {
                            BackgroundColors[simulationCycleIterator] = selectedBC;
                            currentCycle = Cycle.SelectNumber;
                        }
                        else
                        {
                            currentCycle = Cycle.EndTask;
                        }
                        break;
                    case Cycle.SelectNumber:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        if (numbers[simulationCycleIterator] == userValue)
                        {
                            currentCycle = Cycle.S_i;
                        }
                        else
                        {
                            currentCycle = Cycle.EndCycle;
                        }
                        break;
                    case Cycle.EndCycle:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.StepCycle;
                        BackgroundColors[simulationCycleIterator] = whiteBC;
                        simulationCycleIterator++;
                        break;
                    case Cycle.S_i:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        results[0] = simulationCycleIterator + 1;
                        currentCycle = Cycle.EndTask;
                        break;
                    case Cycle.EndTask:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        break;
                }
            }
            TaskBackgroundColors[(int)currentCycle] = Colors.Red;
            OnPropertyChanged(nameof(TaskBackgroundColors));
            OnPropertyChanged(nameof(BackgroundColors));
            OnPropertyChanged(nameof(results));
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
                results[0] = -1;
                currentCycle = Cycle.StartTask;
                OnPropertyChanged(nameof(numbers));
                OnPropertyChanged(nameof(BackgroundColors));
                OnPropertyChanged(nameof(TaskBackgroundColors));
                isSimulationRunning = false;
            }
        }

        private void FillWithRandomNumbers()
        {
            if (!isSimulationRunning)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] = new Random().Next(1, 15);
                }
                OnPropertyChanged(nameof(numbers));
            }
        }
    }
}
