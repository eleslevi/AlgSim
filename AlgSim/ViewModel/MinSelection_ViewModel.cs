using System.Collections.ObjectModel;

namespace AlgSim.ViewModel;

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

    public ObservableCollection<Color> ColorA { get; set; } = new ObservableCollection<Color>()
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

    public ObservableCollection<Color> ColorMI { get; set; } = new ObservableCollection<Color>()
    {
        Colors.LightGray
    };

    public ObservableCollection<Color> ColorM { get; set; } = new ObservableCollection<Color>()
    {
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
    };

    public ObservableCollection<Color> taskBackgroundColors { get; set; } = new ObservableCollection<Color>()
    {
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
        Colors.LightGray,
    };

    private void resetSimulation()
    {
        for (int i = 0; i < A.Count; i++)
        {
            ColorA[i] = Colors.White;
            A[i] = null;
        }
        for (int i = 0; i < M.Count; i++)
        {
            ColorM[i] = Colors.LightGray;
            M[i] = null;
        }
        for (int i = 0; i < taskBackgroundColors.Count; i++)
        {
            taskBackgroundColors[i] = Colors.LightGray;
        }
        ColorMI[0] = Colors.LightGray;
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
                        ColorA[copy] = Colors.LightBlue;
                        ColorM[copy] = Colors.LightBlue;
                    }

                    current_cycle = cycle.start_cycle_A;
                    break;

                case cycle.start_cycle_A:
                    taskBackgroundColors[0] = Colors.LightGray;
                    taskBackgroundColors[9] = Colors.LightGray;
                    taskBackgroundColors[1] = Colors.Red;

                    if (i == 0)
                    {
                        for (int copy = 0; copy < (N + 1); copy++)
                        {
                            ColorA[copy] = Colors.White;
                            ColorM[copy] = Colors.LightGray;
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
                    taskBackgroundColors[1] = Colors.LightGray;
                    taskBackgroundColors[2] = Colors.Red;

                    if (Min < N && i != 0)
                    {
                        ColorM[Min] = Colors.LightGrey;
                    }
                    Min = i;
                    MI[0] = Min + 1;
                    if (Min <= N)
                    {
                        ColorM[Min] = Colors.LightBlue;
                    }

                    if (Min == 0)
                    {
                        ColorM[0] = Colors.LightBlue;
                        ColorMI[0] = Colors.LightBlue;
                        MI[0] = 1;
                    }
                    current_cycle = cycle.start_cycle_B;
                    break;

                case cycle.start_cycle_B:
                    taskBackgroundColors[2] = Colors.LightGray;
                    taskBackgroundColors[7] = Colors.LightGray;
                    taskBackgroundColors[3] = Colors.Red;

                    if (j_temp != 0 && i != N)
                    {
                        if (j_temp > N)
                        {
                            ColorM[(j_temp - 1)] = Colors.LightGrey;
                            j_temp = 0;
                        }
                        else
                        {
                            ColorM[j_temp] = Colors.LightGrey;
                            j_temp = 0;
                        }
                    }

                    if (j <= N)
                    {
                        ColorM[j] = Colors.LightGreen;
                        current_cycle = cycle.start_if;
                    }
                    else
                    {
                        current_cycle = cycle.result_swap;
                    }
                    break;

                case cycle.start_if:
                    taskBackgroundColors[3] = Colors.LightGray;
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
                    taskBackgroundColors[4] = Colors.LightGray;
                    taskBackgroundColors[5] = Colors.Red;


                    if (Min < N)
                    {
                        ColorM[Min] = Colors.LightGrey;
                    }
                    Min = j;
                    if (Min <= N)
                    {
                        ColorM[Min] = Colors.LightBlue;
                    }
                    MI[0] = Min + 1;
                    current_cycle = cycle.end_if;
                    break;

                case cycle.end_if:
                    taskBackgroundColors[4] = Colors.LightGray;
                    taskBackgroundColors[5] = Colors.LightGray;
                    taskBackgroundColors[6] = Colors.Red;

                    current_cycle = cycle.end_cycle_B;
                    break;

                case cycle.end_cycle_B:
                    taskBackgroundColors[6] = Colors.LightGray;
                    taskBackgroundColors[7] = Colors.Red;

                    if (j < N && j != Min)
                    {
                        ColorM[j] = Colors.LightGray;
                    }
                    j++;
                    if (j <= N)
                    {
                        ColorM[j] = Colors.LightGreen;
                    }
                    current_cycle = cycle.start_cycle_B;
                    break;

                case cycle.result_swap:
                    taskBackgroundColors[3] = Colors.LightGray;
                    taskBackgroundColors[8] = Colors.Red;

                    int? swap_i = M[i];
                    int? swap_Min = M[Min];
                    M[i] = swap_Min;
                    M[Min] = swap_i;

                    current_cycle = cycle.end_cycle_A;
                    break;

                case cycle.end_cycle_A:
                    taskBackgroundColors[8] = Colors.LightGray;
                    taskBackgroundColors[9] = Colors.Red;

                    i++;
                    current_cycle = cycle.start_cycle_A;
                    break;

                case cycle.end_MinSelection:
                    taskBackgroundColors[1] = Colors.LightGray;
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