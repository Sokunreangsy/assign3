using assign3.Command;
using assign3.Database;
using assign3.Models;
using assign3.NavState;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace assign3.ViewModels
{
    class ResultMeetingViewModel: ViewModelBase
    {
        private NavigationState _navState;
        private ObservableCollection<Meeting> _meetings;
        private DatabaseContext _db;
        public ICommand OnMeetingClickCommand { get; set; }
        private Meeting _selectedMeeting;
        private int _meetingId;

        public Meeting SelectedMeeting
        {
            get { return _selectedMeeting; }
            set { _selectedMeeting = value; OnPropertyChanged(nameof(SelectedMeeting)); }
        }

        /* public int MeetingId
         {
             get { return _meetingId; }
             set { _meetingId = value; OnPropertyChanged(nameof(MeetingId));}

         }*/
        public ObservableCollection<Meeting> Meetings
        {
            get { return _meetings; }
            set { _meetings = value; OnPropertyChanged(nameof(_meetings)); }

        }

        public ResultMeetingViewModel(int meetingId, NavigationState navState, String preNavState)
        {
            _navState = navState;
            _db = new DatabaseContext();
            _meetingId = meetingId;
            FetchAllMeetings();
        }

        private void FetchAllMeetings()
        {
            Meetings = new ObservableCollection<Meeting>(_db.FetchAllMeetings());
        }


    }
}
