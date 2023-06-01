using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSim.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public DelegateCommand Sum { get; private set; }
        public DelegateCommand MaxSelection { get; private set; }
        public DelegateCommand Intersection { get; private set; }
        public DelegateCommand Union { get; private set; }
        public DelegateCommand Swap { get; private set; }
        public DelegateCommand MinSelection { get; private set; }
        public DelegateCommand Picking { get; private set; }
        public DelegateCommand Bubble { get; private set; }
        public DelegateCommand Splitting { get; private set; }
        public DelegateCommand Copy { get; private set; }
        public DelegateCommand Decision { get; private set; }
        public DelegateCommand Search { get; private set; }
        public DelegateCommand Selection { get; private set; }
        public DelegateCommand Count { get; private set; }

        public EventHandler MenuClicked;


        public MainViewModel() 
        {
            Sum = new DelegateCommand(parameter => OnMenuClicked("Sum"));
            Decision = new DelegateCommand(parameter => OnMenuClicked("Decision"));
            Search = new DelegateCommand(parameter => OnMenuClicked("Search"));
            Selection = new DelegateCommand(parameter => OnMenuClicked("Selection"));
            Count = new DelegateCommand(parameter => OnMenuClicked("Count"));
            MaxSelection = new DelegateCommand(parameter => OnMenuClicked("MaxSelection"));
            Picking = new DelegateCommand(parameter => OnMenuClicked("Picking"));
            Splitting = new DelegateCommand(parameter => OnMenuClicked("Splitting"));
            Bubble = new DelegateCommand(parameter => OnMenuClicked("Bubble"));
            Copy = new DelegateCommand(parameter => OnMenuClicked("Copy"));
            Intersection = new DelegateCommand(parameter => OnMenuClicked("Intersection"));
            Union = new DelegateCommand(parameter => OnMenuClicked("Union"));
            Swap = new DelegateCommand(parameter => OnMenuClicked("Swap"));
            MinSelection = new DelegateCommand(parameter => OnMenuClicked("MinSelection"));
        }

        private void OnMenuClicked(string type_clicked)
        {
            MenuClicked?.Invoke(type_clicked, EventArgs.Empty);
            
        }
    }
}
