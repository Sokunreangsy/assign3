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
        private string _preNavState;
        private Student _aStudent;
        private ObservableCollection<Meeting> _meetings;
        private DatabaseContext _db;
        public ICommand OnBackCommand { get; set; }
        private Meeting _selectedMeeting;
        

        public Student AStudent
        {
            get
            {
                return _aStudent;
            }
            set
            {
                _aStudent = value;
                OnPropertyChanged(nameof(AStudent));
            }
        }
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

        public ResultMeetingViewModel(int studentid, NavigationState navState, string preNavState)
        {
            _navState = navState;
            _preNavState = preNavState;
            _db = new DatabaseContext();
            FetchAStudent(studentid);
            OnBackCommand = new RelayCommand(obj => { this.navHomeView(); });
        }
        public void navHomeView()
        {
            if (_preNavState == "BachelorViewModel")
            {
                _navState.CurrentViewModel = new BachelorViewModel(_navState);
            }
            else
            {
                _navState.CurrentViewModel = new HomeViewModel(_navState);
            }

        }
        private void FetchAStudent(int id)
        {
            AStudent = _db.FetchStudentMeeting(id);
            Meetings = new ObservableCollection<Meeting>(AStudent.MeetingsList);
        }


    }
}
