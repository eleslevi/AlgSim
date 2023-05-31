using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSim.ViewModel
{
    class BubbleOrderPage_ViewModel : ViewModelBase
    {
        public DelegateCommand fillWithRandomNumbers { get; private set; }
        public DelegateCommand resetNumbers { get; private set; }
        public DelegateCommand stepSim { get; private set; }

        private Boolean isSimulationRunning = false;

        private int sim_cycle_iterator_out = 9;
        private int sim_cycle_iterator_in = 0;

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
        };

        public ObservableCollection<double> result { get; set; } = new ObservableCollection<double>()
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
        };

        public ObservableCollection<String> backgroundColors { get; set; } = new ObservableCollection<String>()
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
            StepCycleFirst,
            StepCycleSecond,
            StartIf,
            Switch,
            EndIf,
            EndCycleSecond,
            EndCycleFirst,
            End_Task
        }

        private Cycle current_cycle = Cycle.Start_Task;

        public BubbleOrderPage_ViewModel()
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                result[i] = numbers[i];
            }
            fillWithRandomNumbers = new DelegateCommand(parameter => randomNumbersToFields());
            resetNumbers = new DelegateCommand(parameter => resetSimulation());
            stepSim = new DelegateCommand(parametr => stepSimulation());
        }
        private void stepSimulation()
        {
            if (!isSimulationRunning)
            {
                isSimulationRunning = true;
                for (int i = 0; i < numbers.Count; i++)
                {
                    result[i] = numbers[i];
                }
            }
            else
            {
                switch (current_cycle)
                {
                    case Cycle.Start_Task:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.StepCycleFirst;
                        break;
                    case Cycle.StepCycleFirst:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        if (sim_cycle_iterator_out > 1)
                            current_cycle = Cycle.StepCycleSecond;
                        else
                            current_cycle = Cycle.End_Task;
                        break;
                    case Cycle.StepCycleSecond:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        if (sim_cycle_iterator_in < sim_cycle_iterator_out)
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
                        if (result[sim_cycle_iterator_in] > result[sim_cycle_iterator_in + 1])
                        {
                            var item = result[sim_cycle_iterator_in];
                            result[sim_cycle_iterator_in] = result[sim_cycle_iterator_in + 1];
                            result[sim_cycle_iterator_in + 1] = item;
                        }
                        else
                        {
                            current_cycle = Cycle.EndIf;
                        }
                        break;
                    case Cycle.EndIf:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        current_cycle = Cycle.EndCycleSecond;
                        break;
                    case Cycle.EndCycleSecond:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        sim_cycle_iterator_in++;

                        if (sim_cycle_iterator_in < sim_cycle_iterator_out)
                        {
                            current_cycle = Cycle.StepCycleSecond;
                        }
                        else
                        {
                            current_cycle = Cycle.EndCycleFirst;
                        }
                        //backgroundColors[sim_cycle_iterator] = whiteBC;
                        break;
                    case Cycle.EndCycleFirst:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        sim_cycle_iterator_out--;

                        if (1 < sim_cycle_iterator_out)
                        {
                            current_cycle = Cycle.StepCycleFirst;
                        }
                        else
                        {
                            current_cycle = Cycle.End_Task;
                        }
                        //backgroundColors[sim_cycle_iterator] = whiteBC;
                        break;
                    case Cycle.End_Task:
                        taskBackgroundColors[(int)current_cycle] = Colors.Black;
                        break;
                }
            }
            taskBackgroundColors[(int)current_cycle] = Colors.Red;
            OnPropertyChanged(nameof(taskBackgroundColors));
            OnPropertyChanged(nameof(backgroundColors));
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
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] = 0;
                    numbers[i] = 0;
                }

                sim_cycle_iterator_out = 9;
                sim_cycle_iterator_out = 0;

                OnPropertyChanged(nameof(backgroundColors));
                OnPropertyChanged(nameof(taskBackgroundColors));
                OnPropertyChanged(nameof(result));
            }
        }
    }
}
