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
        public DelegateCommand fillWithRandomNumbers { get; private set; }

        public EventHandler MenuClicked;
        public EventHandler fillWithRandomNumbersClicked;


        public MainViewModel() 
        {
            Sum = new DelegateCommand(parameter => OnMenuClicked("Sum"));
            Decision = new DelegateCommand(parameter => OnMenuClicked("Decision"));

            fillWithRandomNumbers = new DelegateCommand(parameter => randomNumbersToFields());
        }

        private void OnMenuClicked(string type_clicked)
        {
            MenuClicked?.Invoke(type_clicked, EventArgs.Empty);
            
        }

        private void randomNumbersToFields()
        {
            fillWithRandomNumbersClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
