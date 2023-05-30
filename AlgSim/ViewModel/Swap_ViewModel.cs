using System.Collections.ObjectModel;

namespace AlgSim.ViewModel;

public class Swap_ViewModel : ContentPage
{
    public DelegateCommand fillWithRandomNumbers { get; private set; }
    public DelegateCommand resetNumbers { get; private set; }
    public DelegateCommand stepSim { get; private set; }

    private Boolean isSimulationRunning = false;

    private cycle current_cycle = cycle.start_Swap;

    public Swap_ViewModel()
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

    public ObservableCollection<int?> S { get; set; } = new ObservableCollection<int?>()
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

    public ObservableCollection<Color> ColorS { get; set; } = new ObservableCollection<Color>()
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
        for (int i = 0; i < S.Count; i++)
        {
            ColorS[i] = Colors.LightGray;
            S[i] = null;
        }
        for (int i = 0; i < taskBackgroundColors.Count; i++)
        {
            taskBackgroundColors[i] = Colors.LightGray;
        }
        OnPropertyChanged(nameof(ColorA));
        OnPropertyChanged(nameof(A));

        OnPropertyChanged(nameof(ColorS));
        OnPropertyChanged(nameof(S));

        OnPropertyChanged(nameof(taskBackgroundColors));

        current_cycle = cycle.start_Swap;
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
        start_Swap,
        start_cycle_A,
        start_cycle_B,
        start_if,
        result_swap,
        end_if,
        end_cycle_B,
        end_cycle_A,
        end_Swap
    }

    int i;
    int j;
    int N;
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
                case cycle.start_Swap:
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
                        S[copy] = A[copy];
                        ColorA[copy] = Colors.LightBlue;
                        ColorS[copy] = Colors.LightBlue;
                    }

                    current_cycle = cycle.start_cycle_A;
                    break;

                case cycle.start_cycle_A:
                    taskBackgroundColors[0] = Colors.LightGray;
                    taskBackgroundColors[7] = Colors.LightGray;
                    taskBackgroundColors[1] = Colors.Red;

                    if (i == 0)
                    {
                        for (int copy = 0; copy < (N + 1); copy++)
                        {
                            ColorA[copy] = Colors.White;
                            ColorS[copy] = Colors.LightGray;
                        }
                    }

                    if (i <= N)
                    {
                        current_cycle = cycle.start_cycle_B;
                        if (i == 0)
                        {
                            ColorS[(0)] = Colors.LightBlue;
                        }
                    }
                    else
                    {
                        current_cycle = cycle.end_Swap;
                    }

                    j_temp = j;
                    j = i + 1;
                    break;

                case cycle.start_cycle_B:
                    taskBackgroundColors[1] = Colors.LightGray;
                    taskBackgroundColors[6] = Colors.LightGray;
                    taskBackgroundColors[2] = Colors.Red;

                    if (j_temp != 0 && i != N)
                    {
                        if (j_temp > N)
                        {
                            ColorS[(j_temp - 1)] = Colors.LightGrey;
                            j_temp = 0;
                        }
                        else
                        {
                            ColorS[j_temp] = Colors.LightGrey;
                            j_temp = 0;
                        }
                    }

                    if (j <= N)
                    {
                        ColorS[j] = Colors.LightGreen;
                        current_cycle = cycle.start_if;
                    }
                    else
                    {
                        current_cycle = cycle.end_cycle_A;
                    }
                    break;

                case cycle.start_if:
                    taskBackgroundColors[2] = Colors.LightGray;
                    taskBackgroundColors[3] = Colors.Red;

                    if (S[i] > S[j])
                    {
                        current_cycle = cycle.result_swap;
                    }
                    else
                    {
                        current_cycle = cycle.end_if;
                    }
                    break;

                case cycle.result_swap:
                    taskBackgroundColors[3] = Colors.LightGray;
                    taskBackgroundColors[4] = Colors.Red;

                    int? swap_i = S[i];
                    int? swap_j = S[j];
                    S[i] = swap_j;
                    S[j] = swap_i;

                    current_cycle = cycle.end_if;
                    break;

                case cycle.end_if:
                    taskBackgroundColors[3] = Colors.LightGray;
                    taskBackgroundColors[4] = Colors.LightGray;
                    taskBackgroundColors[5] = Colors.Red;

                    current_cycle = cycle.end_cycle_B;
                    break;

                case cycle.end_cycle_B:
                    taskBackgroundColors[5] = Colors.LightGray;
                    taskBackgroundColors[6] = Colors.Red;

                    if (j < N)
                    {
                        ColorS[j] = Colors.LightGray;
                    }
                    j++;
                    if (j <= N)
                    {
                        ColorS[j] = Colors.LightGreen;
                    }
                    current_cycle = cycle.start_cycle_B;
                    break;

                case cycle.end_cycle_A:
                    taskBackgroundColors[2] = Colors.LightGray;
                    taskBackgroundColors[7] = Colors.Red;

                    if (i < N)
                    {
                        ColorS[i] = Colors.LightGrey;
                    }
                    i++;
                    if (i <= N)
                    {
                        ColorS[i] = Colors.LightBlue;
                    }

                    current_cycle = cycle.start_cycle_A;
                    break;

                case cycle.end_Swap:
                    taskBackgroundColors[1] = Colors.LightGray;
                    taskBackgroundColors[8] = Colors.Red;

                    isSimulationRunning = false;
                    break;
            }
        }

        OnPropertyChanged(nameof(taskBackgroundColors));
        OnPropertyChanged(nameof(ColorA));
        OnPropertyChanged(nameof(ColorS));

        OnPropertyChanged(nameof(S));
    }

}