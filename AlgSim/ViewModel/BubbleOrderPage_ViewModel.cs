using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private int sim_cycle_iterator = 0;

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
    }
}
