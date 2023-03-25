using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSim.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public DelegateCommand DisplayMessage { get; private set; }

        public EventHandler MenuClicked;


        public MainViewModel() 
        {
            DisplayMessage = new DelegateCommand(parameter => OnMenuClicked());
        }

        private void OnMenuClicked()
        {
            MenuClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
