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
        public DelegateCommand Decision { get; private set; }
        public DelegateCommand MaxSelection { get; private set; }
        public DelegateCommand Intersection { get; private set; }
        public DelegateCommand Union { get; private set; }
        public DelegateCommand Swap { get; private set; }
        public DelegateCommand MinSelection { get; private set; }

        public EventHandler MenuClicked;


        public MainViewModel() 
        {
            Sum = new DelegateCommand(parameter => OnMenuClicked("Sum"));
            Decision = new DelegateCommand(parameter => OnMenuClicked("Decision"));
            MaxSelection = new DelegateCommand(parameter => OnMenuClicked("MaxSelection"));
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
