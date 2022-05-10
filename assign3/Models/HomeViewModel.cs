using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Input;

using assign3.Models;
using assign3.Database;
using assign3.Command;
using System.Runtime.CompilerServices;
using assign3.NavState;


namespace assign3.Models
{
    public class HomeViewModel:ViewModelBase
    {
        // navigation bar
        private readonly NavigationState _navState;

        public ViewModelBase CurrentViewModel { get; set; }
        private DatabaseContext _db;
        // meeting
        public ICommand SelectMeetingCommand { get; set; }
        public ICommand SearchMeetingCommand { get; set; }  //search all meeting for a student
        public ICommand NavigateResultCommand { get; set; }

        private ObservableCollection<Meeting> _meetings;





    }
}
