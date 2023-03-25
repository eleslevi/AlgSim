using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlgSim
{
    public class MainPageBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Sum { get; set; }
        public ICommand Decision { get; set; }
        public ICommand Copy { get; set; }
        public ICommand Selection { get; set; }
        public ICommand SimpleSwap { get; set; }
        public ICommand MinimumSelection { get; set; }
    }
}
