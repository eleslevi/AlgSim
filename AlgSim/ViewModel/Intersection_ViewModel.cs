using System.Collections.ObjectModel;

namespace AlgSim.ViewModel;

public class Intersection_ViewModel : ContentPage
{
    public DelegateCommand fillWithRandomNumbers { get; private set; }
    public DelegateCommand resetNumbers { get; private set; }
    public DelegateCommand stepSim { get; private set; }

    private Boolean isSimulationRunning = false;

    private cycle current_cycle = cycle.start_Intersection;

    public Intersection_ViewModel()
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

    public ObservableCollection<int?> I { get; set; } = new ObservableCollection<int?>()
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

    public ObservableCollection<int?> B { get; set; } = new ObservableCollection<int?>()
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

    public ObservableCollection<Color> ColorI { get; set; } = new ObservableCollection<Color>()
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

    public ObservableCollection<Color> ColorB { get; set; } = new ObservableCollection<Color>()
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
        for (int i = 0; i < I.Count; i++)
        {
            ColorI[i] = Colors.LightGray;
            I[i] = null;
        }
        for (int i = 0; i < B.Count; i++)
        {
            ColorB[i] = Colors.White;
            B[i] = null;
        }
        for (int i = 0; i < taskBackgroundColors.Count; i++)
        {
            taskBackgroundColors[i] = Colors.LightGray;
        }
        OnPropertyChanged(nameof(ColorA));
        OnPropertyChanged(nameof(A));

        OnPropertyChanged(nameof(ColorI));
        OnPropertyChanged(nameof(I));
            
        OnPropertyChanged(nameof(ColorB));
        OnPropertyChanged(nameof(B));

        OnPropertyChanged(nameof(taskBackgroundColors));

        current_cycle = cycle.start_Intersection;
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

            for (int i = 0; i < B.Count; i++)
            {
                B[i] = new Random().Next(0, 100);
            }

            OnPropertyChanged(nameof(A));
            OnPropertyChanged(nameof(B));
        }
    }

    private enum cycle
    {
        start_Intersection,
        tracker_Intersection,
        start_cycle_A,
        tracker_B,
        start_cycle_B,
        add_tracker_B,
        end_cycle_B,
        start_if,
        add_tracker_Intersection,
        add_result_Intersection,
        end_if,
        end_cycle_A,
        end_Intersection
    }

    int i;
    int j;
    int N;
    int M;
    int DB;

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
                case cycle.start_Intersection:
                    taskBackgroundColors[0] = Colors.Red;

                    i = 0;
                    j = 0;
                    N = 0;
                    M = 0;
                    for (int temp = 0; temp < 9; temp++)
                    {
                        if(A[(temp + 1)] != null)
                        {
                            N++;
                        }
                        if (B[(temp + 1)] != null)
                        {
                            M++;
                        }
                    }

                    current_cycle = cycle.tracker_Intersection;
                    break;

                case cycle.tracker_Intersection:
                    taskBackgroundColors[0] = Colors.LightGray;
                    taskBackgroundColors[1] = Colors.Red;

                    DB = -1;
                    current_cycle = cycle.start_cycle_A;
                    break;

                case cycle.start_cycle_A:
                    taskBackgroundColors[1] = Colors.LightGray;
                    taskBackgroundColors[11] = Colors.LightGray;
                    taskBackgroundColors[2] = Colors.Red;

                    if(i <= N)
                    {
                        current_cycle = cycle.tracker_B;
                        if (i == 0)
                        {
                            ColorA[(0)] = Colors.LightBlue;
                        }
                    }
                    else
                    {
                        current_cycle = cycle.end_Intersection;
                    }
                    break;

                case cycle.tracker_B:
                    taskBackgroundColors[2] = Colors.LightGray;
                    taskBackgroundColors[3] = Colors.Red;

                    if (j != 0)
                    {
                        if(j > M)
                        {
                            ColorB[(j - 1)] = Colors.White;
                        }
                        else
                        {
                            ColorB[j] = Colors.White;
                        }
                    }
                    j = 0;
                    ColorB[(0)] = Colors.LightBlue;
                    current_cycle = cycle.start_cycle_B;
                    break;

                case cycle.start_cycle_B:
                    taskBackgroundColors[6] = Colors.LightGray;
                    taskBackgroundColors[3] = Colors.LightGray;
                    taskBackgroundColors[4] = Colors.Red;

                    if(j <= M && A[i] != B[j])
                    {
                        current_cycle = cycle.add_tracker_B;
                    }
                    else
                    {
                        current_cycle = cycle.start_if;
                    }
                    break;

                case cycle.add_tracker_B:
                    taskBackgroundColors[4] = Colors.LightGray;
                    taskBackgroundColors[5] = Colors.Red;

                    if (j < M)
                    {
                        ColorB[j] = Colors.White;
                    }
                    j++;
                    if(j <= M)
                    {
                        ColorB[j] = Colors.LightBlue;
                    }
                    current_cycle = cycle.end_cycle_B;
                    break;

                case cycle.end_cycle_B:
                    taskBackgroundColors[5] = Colors.LightGray;
                    taskBackgroundColors[6] = Colors.Red;

                    current_cycle = cycle.start_cycle_B;
                    break;

                case cycle.start_if:
                    taskBackgroundColors[4] = Colors.LightGray;
                    taskBackgroundColors[6] = Colors.LightGray;
                    taskBackgroundColors[7] = Colors.Red;

                    if(j <= M)
                    {
                        current_cycle = cycle.add_tracker_Intersection;
                    }
                    else
                    {
                        current_cycle = cycle.end_if;
                    }
                    break;

                case cycle.add_tracker_Intersection:
                    taskBackgroundColors[7] = Colors.LightGray;
                    taskBackgroundColors[8] = Colors.Red;

                    if (DB < 9)
                    {
                        if(DB != -1)
                        {
                            ColorI[DB] = Colors.LightGray;
                        }
                    }
                    DB++;
                    if (DB <= 9)
                    {
                        ColorI[DB] = Colors.LightBlue;
                    }
                    current_cycle = cycle.add_result_Intersection;
                    break;

                case cycle.add_result_Intersection:
                    taskBackgroundColors[8] = Colors.LightGray;
                    taskBackgroundColors[9] = Colors.Red;

                    I[DB] = A[i];
                    current_cycle = cycle.end_if;
                    break;

                case cycle.end_if:
                    taskBackgroundColors[7] = Colors.LightGray;
                    taskBackgroundColors[9] = Colors.LightGray;
                    taskBackgroundColors[10] = Colors.Red;

                    current_cycle = cycle.end_cycle_A;
                    break;

                case cycle.end_cycle_A:
                    taskBackgroundColors[2] = Colors.LightGray;
                    taskBackgroundColors[10] = Colors.LightGray;
                    taskBackgroundColors[11] = Colors.Red;

                    if (i < N)
                    {
                        ColorA[i] = Colors.White;
                    }
                    i++;
                    if(i <= N)
                    {
                        ColorA[i] = Colors.LightBlue;
                    }
                    current_cycle = cycle.start_cycle_A;
                    break;

                case cycle.end_Intersection:
                    taskBackgroundColors[2] = Colors.LightGray;
                    taskBackgroundColors[12] = Colors.Red;

                    isSimulationRunning = false;
                    break;
            }
        }

        OnPropertyChanged(nameof(taskBackgroundColors));
        OnPropertyChanged(nameof(ColorA));
        OnPropertyChanged(nameof(ColorI));
        OnPropertyChanged(nameof(ColorB));

        OnPropertyChanged(nameof(I));
    }

}