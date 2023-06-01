using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlgSim.ViewModel
{
    public class KivalasztasPage_ViewModel : ViewModelBase
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
        Colors.White,
        Colors.White,
        Colors.White,
        Colors.White,
        };
        public int SelectedNumber { get; private set; } = -1;

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
                        currentCycle = Cycle.InitSelection;
                        SelectedNumber = -1;
                        break;
                    case Cycle.InitSelection:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        if (simulationCycleIterator < numbers.Count)
                        {
                            currentCycle = Cycle.SelectNumber;
                        }
                        else
                        {
                            currentCycle = Cycle.S_i;
                        }
                        break;
                    case Cycle.SelectNumber:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        SelectedNumber = numbers[simulationCycleIterator];
                        currentCycle = Cycle.EndCycle;
                        BackgroundColors[simulationCycleIterator] = selectedBC;
                        break;
                    case Cycle.EndCycle:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.StepCycle;
                        BackgroundColors[simulationCycleIterator] = whiteBC;
                        simulationCycleIterator++;
                        break;
                    case Cycle.S_i:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.EndTask;
                        break;
                    case Cycle.EndTask:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        break;
                }
            }
            TaskBackgroundColors[(int)currentCycle] = Colors.Red;
            OnPropertyChanged(nameof(TaskBackgroundColors));
            OnPropertyChanged(nameof(BackgroundColors));
            OnPropertyChanged(nameof(SelectedNumber));
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
                SelectedNumber = -1;
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
