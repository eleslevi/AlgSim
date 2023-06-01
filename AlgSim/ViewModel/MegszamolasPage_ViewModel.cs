using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AlgSim.ViewModel
{
    public class MegszamolasPage_ViewModel : ViewModelBase
    {
        public DelegateCommand FillWithRandomNumbersCommand { get; }
        public DelegateCommand ResetNumbersCommand { get; }
        public DelegateCommand StepSimulationCommand { get; }

        private bool isSimulationRunning = false;
        private int simulationCycleIterator = 0;

        private Color whiteBC = Colors.White;
        private Color selectedBC = Colors.LightBlue;

        public ObservableCollection<int> Occurrences { get; } = new ObservableCollection<int>();
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
                        currentCycle = Cycle.InitOccurrences;
                        break;
                    case Cycle.InitOccurrences:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        if (simulationCycleIterator < numbers.Count)
                        {
                            currentCycle = Cycle.CountOccurrences;
                        }
                        else
                        {
                            currentCycle = Cycle.EndTask;
                        }
                        break;
                    case Cycle.CountOccurrences:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.EndCycle;
                        BackgroundColors[simulationCycleIterator] = selectedBC;
                        break;
                    case Cycle.EndCycle:
                        TaskBackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.StepCycle;
                        Occurrences[numbers[simulationCycleIterator]]++;
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
            OnPropertyChanged(nameof(Occurrences));
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
                Occurrences.Clear();
                for (int i = 0; i < 15; i++)
                {
                    Occurrences.Add(0);
                }
                OnPropertyChanged(nameof(numbers));
                OnPropertyChanged(nameof(Occurrences));
            }
        }
    }
}
