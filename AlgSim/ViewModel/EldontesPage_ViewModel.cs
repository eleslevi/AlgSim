using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace AlgSim.ViewModel
{
    public class EldontesPage_ViewModel : ViewModelBase
    {
        public DelegateCommand FillWithRandomNumbersCommand { get; }
        public DelegateCommand ResetNumbersCommand { get; }
        public DelegateCommand StepSimulationCommand { get; }
        public DelegateCommand legorduloCommand { get; }
        public List<string> PickerItems { get; } = new List<string>
        {
            "Páros szám",
            "Páratlan szám",
            "konkrét érték",
        };

        private string entryValue;
        public string EntryValue
        {
            get { return entryValue; }
            set
            {
                entryValue = value;
                OnPropertyChanged(nameof(EntryValue));
            }
        }

        private string selectedPickerItem;
        public string SelectedPickerItem
        {
            get { return selectedPickerItem; }
            set
            {
                selectedPickerItem = value;
                OnPropertyChanged(nameof(SelectedPickerItem));
            }
        }

        private bool isSimulationRunning = false;
        private int simulationCycleIterator = 0;

        private Color whiteBC = Colors.White;
        private Color selectedBC = Colors.LightBlue;

        public ObservableCollection<int> currentEldontes { get; } = new ObservableCollection<int> { 0 };
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
        public ObservableCollection<Color> backgroundColors { get; } = new ObservableCollection<Color>()
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
        public ObservableCollection<Color> TaskbackgroundColors { get; } = new ObservableCollection<Color>()
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
        Colors.White,
        };

        private enum Cycle
        {
            StartTask,
            InitSum,
            StepCycle,
            AddNumbers,
            EndCycle,
            ha,
            i_van,
            azonban,
            i_nincs,
            elagazas,
            EndTask
        }

        private Cycle currentCycle = Cycle.StartTask;

        public EldontesPage_ViewModel()
        {
            FillWithRandomNumbersCommand = new DelegateCommand(parameter => FillWithRandomNumbers());
            ResetNumbersCommand = new DelegateCommand(parameter => ResetSimulation());
            StepSimulationCommand = new DelegateCommand(parameter => StepSimulation());
            legorduloCommand = new DelegateCommand(parameter => legordulo());
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
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.InitSum;
                        if (SelectedPickerItem == "Páros szám") ;
                        else if (SelectedPickerItem == "Páratlan szám") ;
                        else if (SelectedPickerItem == "Konkrét érték") ;

                        break;
                    case Cycle.InitSum:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.StepCycle;
                        break;
                    case Cycle.StepCycle:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        if (simulationCycleIterator < numbers.Count)
                        {
                            currentCycle = Cycle.AddNumbers;
                        }
                        else
                        {
                            currentCycle = Cycle.ha;
                        }
                        break;
                    case Cycle.AddNumbers:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.EndCycle;
                        backgroundColors[simulationCycleIterator] = selectedBC;
                        break;
                    case Cycle.EndCycle:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.StepCycle;
                        currentEldontes[0] += numbers[simulationCycleIterator];
                        backgroundColors[simulationCycleIterator] = whiteBC;
                        simulationCycleIterator++;
                        break;
                    case Cycle.ha:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.i_van;
                        break;
                    case Cycle.i_van:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.azonban;
                        break;
                    case Cycle.azonban:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.i_nincs;
                        break;
                    case Cycle.i_nincs:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.elagazas;
                        break;
                    case Cycle.elagazas:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
                        currentCycle = Cycle.EndTask;
                        break;
                    case Cycle.EndTask:
                        TaskbackgroundColors[(int)currentCycle] = whiteBC;
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
                    backgroundColors[i] = whiteBC;
                }
                OnPropertyChanged(nameof(backgroundColors));
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
        private void legordulo()
        {

        }
    }
}
