using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using assign3.Command;
using assign3.Database;
using assign3.Models;
namespace assign3.Models
{
    class ResultMeetingViewModel: ViewModelBase
    {

        private ObservableCollection<Meeting> _meetings;
        public List<StudentMeeting> StudentMeetings { get; set; }
        private DatabaseContext _db;
        public ICommand OnMeetingClickCommand { get; set; }
        private bool _isColumnVisible;
        private Meeting _selectedMeeting;
        private int _meetingId;

        public bool IsColumnVisible
        {
            get{return _isColumnVisible;}
            set{_isColumnVisible = value; OnPropertyChanged(nameof(IsColumnVisible));}
        }

        public Meeting SelectedMeeting
        {
            get{return _selectedMeeting;}
            set{_selectedMeeting = value; OnPropertyChanged(nameof(SelectedMeeting));}
        }

       /* public int MeetingId
        {
            get { return _meetingId; }
            set { _meetingId = value; OnPropertyChanged(nameof(MeetingId));}
            
        }*/
        public ObservableCollection<Meeting> Meetings
        {
            get{ return _meetings;}
            set{_meetings = value; OnPropertyChanged(nameof(_meetings));}

        }

        public ResultMeetingViewModel(int meetingId)
        {
            _db = new DatabaseContext();
            _meetingId = meetingId;
            OnMeetingClickCommand = new RelayCommand(obj => { this.FetchAMeeting(); });
            FetchAllMeetings();
        }

        private void FetchAllMeetings()
        { 
            Meetings= new ObservableCollection<Meeting>(_db.FetchAllMeetings());
        }

        private void FetchAMeeting()
        {
            IsColumnVisible = true;
        }



    }
}
