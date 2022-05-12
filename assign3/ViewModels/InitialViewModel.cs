using assign3.Command;
using assign3.NavState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace assign3.ViewModels
{
    class InitialViewModel: ViewModelBase
    {
        //commands to bechelor or master view
        public ICommand NavigateMainCommand { get; set; }
        private readonly NavigationState _navState;
        public ICommand NavigateBachelorCommand { get; set; }


        public InitialViewModel(NavigationState navState)
        {
            _navState = navState;
            NavigateMainCommand = new RelayCommand(obj => { this.navHomeView(); });
            NavigateBachelorCommand = new RelayCommand(obj => { this.navBachelorView(); });
        }
        
        private void navHomeView()
        {
            _navState.CurrentViewModel = new HomeViewModel(_navState);
        }
        private void navBachelorView()
        {
            _navState.CurrentViewModel = new BachelorViewModel(_navState);
        }
    }
}
