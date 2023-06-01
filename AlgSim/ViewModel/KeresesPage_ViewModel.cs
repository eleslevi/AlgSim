using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlgSim.ViewModel
{
    public class KeresesPage_ViewModel : ViewModelBase
    {
        public DelegateCommand FillWithRandomNumbersCommand { get; }
        public DelegateCommand ResetNumbersCommand { get; }
        public DelegateCommand StepSimulationCommand { get; }

        private bool isSimulationRunning = false;
        private int simulationCycleIterator = 0;

        private Color whiteBC = Colors.White;
        private Color selectedBC = Colors.LightBlue;

        public ObservableCollection<int> numbers { get; } = new ObservableCollection<int>()
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
        public ObservableCollection<Color> BackgroundColors { get; } = new ObservableCollection<Color>()
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
        public ObservableCollection<Color> TaskBackgroundColors { get; } = new ObservableCollection<Color>()
        {
            Colors.White,
            Colors.White,
            Colors.White,
            Colors.White,
            Colors.White,
            Colors.White,
        };
        public int TargetNumber { get; set; }
        public int FoundIndex { get; private set; } = -1;

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
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.InitSearch;
                        FoundIndex = -1;
                        break;
                    case Cycle.InitSearch:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
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
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        if (numbers[simulationCycleIterator] == TargetNumber)
                        {
                            FoundIndex = simulationCycleIterator;
                            currentCycle = Cycle.EndTask;
                        }
                        else
                        {
                            currentCycle = Cycle.EndCycle;
                            BackgroundColors[simulationCycleIterator] = selectedBC;
                        }
                        break;
                    case Cycle.EndCycle:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.StepCycle;
                        BackgroundColors[simulationCycleIterator] = whiteBC;
                        simulationCycleIterator++;
                        break;
                    case Cycle.EndTask:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        break;
                }
            }
            TaskBackgroundColors[(int)currentCycle] = Colors.Red;
            OnPropertyChanged(nameof(TaskBackgroundColors));
            OnPropertyChanged(nameof(BackgroundColors));
            OnPropertyChanged(nameof(FoundIndex));
        }

        private void ResetSimulation()
        {
            if (isSimulationRunning)
            {
                for (int i = 0; i < BackgroundColors.Count; i++)
                {
                    BackgroundColors[i] = whiteBC;
                }
                OnPropertyChanged(nameof(BackgroundColors));
                FoundIndex = -1;
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
