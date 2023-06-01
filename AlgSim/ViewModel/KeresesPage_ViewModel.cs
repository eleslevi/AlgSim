using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlgSim.ViewModel
{
    public class KeresesPage_ViewModel : ViewModelBase
    {
        public DelegateCommand FillWithRandomNumbersCommand { get; private set; }
        public DelegateCommand ResetSimulationCommand { get; private set; }
        public DelegateCommand StepSimulationCommand { get; private set; }

        private bool isSimulationRunning = false;
        private int simulationCycleIterator = 0;

        public static int userValue = 0;

        private String whiteBC = "White";
        private String selectedBC = "LightBlue";

        public ObservableCollection<object> results { get; set; } = new ObservableCollection<object>()
        {
            "", 
            -1,
        };

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

        private enum Cycle
        {
            StartTask,
            InitSearch,
            StepCycle,
            CheckNumber,
            EndCycle,
            EndTask
        }

        private Cycle currentCycle = Cycle.StartTask;

        public KeresesPage_ViewModel()
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
                        currentCycle = Cycle.InitSearch;
                        break;
                    case Cycle.InitSearch:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        currentCycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        BackgroundColors[simulationCycleIterator] = selectedBC;
                        if (simulationCycleIterator < numbers.Count)
                        {
                            currentCycle = Cycle.CheckNumber;
                        }
                        else
                        {
                            currentCycle = Cycle.EndTask;
                        }
                        break;
                    case Cycle.CheckNumber:
                        TaskBackgroundColors[(int)currentCycle] = Colors.Black;
                        if (numbers[simulationCycleIterator] == userValue)
                        {
                            results[0] = "Igen";
                            results[1] = simulationCycleIterator;
                            currentCycle = Cycle.EndTask;
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
                for(int i = 0; i < TaskBackgroundColors.Count; i++)
                {
                    TaskBackgroundColors[i] = Colors.Black;
                }
                userValue = 0;
                currentCycle = Cycle.StartTask;
                simulationCycleIterator = 0;
                results[0] = "";
                results[1] = -1;
                OnPropertyChanged(nameof(results));
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
