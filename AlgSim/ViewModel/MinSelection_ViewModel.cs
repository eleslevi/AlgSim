using System.Collections.ObjectModel;
using AlgSim.ViewModel;

namespace AlgSim.View;

public class MinSelection_ViewModel : ContentPage
{
    public DelegateCommand fillWithRandomNumbers { get; private set; }
    public DelegateCommand resetNumbers { get; private set; }
    public DelegateCommand stepSim { get; private set; }

    private Boolean isSimulationRunning = false;

    private cycle current_cycle = cycle.start_MinSelection;

    public MinSelection_ViewModel()
    {
        fillWithRandomNumbers = new DelegateCommand(parameter => randomNumbersToFields());
        resetNumbers = new DelegateCommand(parameter => resetSimulation());
        stepSim = new DelegateCommand(parametr => stepSimulation());
    }

    public ObservableCollection<int?> A { get; set; } = new ObservableCollection<int?>()
    {
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
    };

    public ObservableCollection<int?> MI { get; set; } = new ObservableCollection<int?>()
    {
        null
    };

    public ObservableCollection<int?> M { get; set; } = new ObservableCollection<int?>()
    {
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
    };

    public ObservableCollection<String> ColorA { get; set; } = new ObservableCollection<String>()
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
    
    public ObservableCollection<String> ColorMI { get; set; } = new ObservableCollection<String>()
    {
        "LightGray"
    };

    public ObservableCollection<String> ColorM { get; set; } = new ObservableCollection<String>()
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
        Colors.Black,
        Colors.Black,
        Colors.Black,
        Colors.Black,
    };

    private void resetSimulation()
    {
        for (int i = 0; i < A.Count; i++)
        {
            ColorA[i] = "White";
            A[i] = null;
        }
        for (int i = 0; i < M.Count; i++)
        {
            ColorM[i] = "White";
            M[i] = null;
        }
        for (int i = 0; i < taskBackgroundColors.Count; i++)
        {
            taskBackgroundColors[i] = Colors.Black;
        }
        ColorMI[0] = "White";
        MI[0] = null;

        OnPropertyChanged(nameof(ColorA));
        OnPropertyChanged(nameof(A));

        OnPropertyChanged(nameof(ColorM));
        OnPropertyChanged(nameof(M));

        OnPropertyChanged(nameof(ColorMI));
        OnPropertyChanged(nameof(MI));

        OnPropertyChanged(nameof(taskBackgroundColors));

        current_cycle = cycle.start_MinSelection;
        isSimulationRunning = false;
    }

    private void randomNumbersToFields()
    {
        if (!isSimulationRunning)
        {
            for (int i = 0; i < A.Count; i++)
            {
                A[i] = new Random().Next(0, 100);
            }

            OnPropertyChanged(nameof(A));
        }
    }

    private enum cycle
    {
        start_MinSelection,
        start_cycle_A,
        tracker_Min,
        start_cycle_B,
        start_if,
        add_tracker_Min,
        end_if,
        end_cycle_B,
        result_swap,
        end_cycle_A,
        end_MinSelection
    }

    int i;
    int j;
    int N;
    int Min;
    int j_temp;

    private void stepSimulation()
    {

        if (!isSimulationRunning)
        {
            isSimulationRunning = true;
            stepSimulation();
        }
        else
        {
            switch (current_cycle)
            {
                case cycle.start_MinSelection:
                    taskBackgroundColors[0] = Colors.Red;

                    i = 0;
                    j = 0;
                    N = 0;
                    for (int temp = 0; temp < 9; temp++)
                    {
                        if (A[(temp + 1)] != null)
                        {
                            N++;
                        }
                    }

                    for (int copy = 0; copy < (N + 1); copy++)
                    {
                        M[copy] = A[copy];
                        ColorA[copy] = "LightBlue";
                        ColorM[copy] = "LightBlue";
                    }

                    current_cycle = cycle.start_cycle_A;
                    break;

                case cycle.start_cycle_A:
                    taskBackgroundColors[0] = Colors.Black;
                    taskBackgroundColors[9] = Colors.Black;
                    taskBackgroundColors[1] = Colors.Red;

                    if (i == 0)
                    {
                        for (int copy = 0; copy < (N + 1); copy++)
                        {
                            ColorA[copy] = "White";
                            ColorM[copy] = "White";
                        }
                    }

                    if (i <= N)
                    {
                        current_cycle = cycle.tracker_Min;
                    }
                    else
                    {
                        current_cycle = cycle.end_MinSelection;
                    }

                    j_temp = j;
                    j = i + 1;
                    break;

                case cycle.tracker_Min:
                    taskBackgroundColors[1] = Colors.Black;
                    taskBackgroundColors[2] = Colors.Red;

                    if (Min < N && i != 0)
                    {
                        ColorM[Min] = "White";
                    }
                    Min = i;
                    MI[0] = Min + 1;
                    if (Min <= N)
                    {
                        ColorM[Min] = "LightBlue";
                    }

                    if (Min == 0)
                    {
                        ColorM[0] = "LightBlue";
                        ColorMI[0] = "LightBlue";
                        MI[0] = 1;
                    }
                    current_cycle = cycle.start_cycle_B;
                    break;

                case cycle.start_cycle_B:
                    taskBackgroundColors[2] = Colors.Black;
                    taskBackgroundColors[7] = Colors.Black;
                    taskBackgroundColors[3] = Colors.Red;

                    if (j_temp != 0 && i != N)
                    {
                        if (j_temp > N)
                        {
                            ColorM[(j_temp - 1)] = "White";
                            j_temp = 0;
                        }
                        else
                        {
                            ColorM[j_temp] = "White";
                            j_temp = 0;
                        }
                    }

                    if (j <= N)
                    {
                        ColorM[j] = "LightGreen";
                        current_cycle = cycle.start_if;
                    }
                    else
                    {
                        current_cycle = cycle.result_swap;
                    }
                    break;

                case cycle.start_if:
                    taskBackgroundColors[3] = Colors.Black;
                    taskBackgroundColors[4] = Colors.Red;

                    if (M[Min] > M[j])
                    {
                        current_cycle = cycle.add_tracker_Min;
                    }
                    else
                    {
                        current_cycle = cycle.end_if;
                    }
                    break;

                case cycle.add_tracker_Min:
                    taskBackgroundColors[4] = Colors.Black;
                    taskBackgroundColors[5] = Colors.Red;


                    if (Min < N)
                    {
                        ColorM[Min] = "White";
                    }
                    Min = j;
                    if (Min <= N)
                    {
                        ColorM[Min] = "LightBlue";
                    }
                    MI[0] = Min + 1;
                    current_cycle = cycle.end_if;
                    break;

                case cycle.end_if:
                    taskBackgroundColors[4] = Colors.Black;
                    taskBackgroundColors[5] = Colors.Black;
                    taskBackgroundColors[6] = Colors.Red;

                    current_cycle = cycle.end_cycle_B;
                    break;

                case cycle.end_cycle_B:
                    taskBackgroundColors[6] = Colors.Black;
                    taskBackgroundColors[7] = Colors.Red;

                    if (j < N && j != Min)
                    {
                        ColorM[j] = "White";
                    }
                    j++;
                    if (j <= N)
                    {
                        ColorM[j] = "LightGreen";
                    }
                    current_cycle = cycle.start_cycle_B;
                    break;

                case cycle.result_swap:
                    taskBackgroundColors[3] = Colors.Black;
                    taskBackgroundColors[8] = Colors.Red;

                    int? swap_i = M[i];
                    int? swap_Min = M[Min];
                    M[i] = swap_Min;
                    M[Min] = swap_i;

                    current_cycle = cycle.end_cycle_A;
                    break;

                case cycle.end_cycle_A:
                    taskBackgroundColors[8] = Colors.Black;
                    taskBackgroundColors[9] = Colors.Red;

                    i++;
                    current_cycle = cycle.start_cycle_A;
                    break;

                case cycle.end_MinSelection:
                    taskBackgroundColors[1] = Colors.Black;
                    taskBackgroundColors[10] = Colors.Red;

                    isSimulationRunning = false;
                    break;
            }
        }

        OnPropertyChanged(nameof(taskBackgroundColors));
        OnPropertyChanged(nameof(ColorA));
        OnPropertyChanged(nameof(ColorM));
        OnPropertyChanged(nameof(ColorMI));
        OnPropertyChanged(nameof(M));
        OnPropertyChanged(nameof(MI));
    }

}