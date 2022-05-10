
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
using assign3.NavState;

namespace assign3.ViewModels
{
    class ResultClassViewModel : ViewModelBase
    {
        private ObservableCollection<Class> _classes ;

        private ObservableCollection<StudentGroup> _selectedStudentGroups;

        private DatabaseContext _db;

        private readonly NavigationState _navState;
        public ICommand OnClassClickCommand { get; set; }
        private bool _isColumnVisible;
        private Class _selectedClass;
        private int _classId;

        private string _day;
        private string _start;
        private string _end;
        private string _room;
        public ICommand OnBackNavCommand { get; set; }
        


        public string Day
        {
            get
            {
                return _day;
            }
            set
            {
                _day = value;
                OnPropertyChanged(nameof(Day));
            }
        }
        public string Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
                OnPropertyChanged(nameof(Start));
            }
        }
        public string End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
                OnPropertyChanged(nameof(End));
            }
        }
        public string Room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;
                OnPropertyChanged(nameof(Room));
            }
        }
        public ObservableCollection<StudentGroup> SelectedStudentGroups
        {
            get
            {
                return _selectedStudentGroups;
            }
            set
            {
                _selectedStudentGroups = value;
                OnPropertyChanged(nameof(SelectedStudentGroups));
            }
        }
        public bool IsColumnVisible
        {
            get
            {
                return _isColumnVisible;
            }
            set
            {
                _isColumnVisible = value;
                OnPropertyChanged(nameof(IsColumnVisible));
            }
        }
        public Class SelectedClass
        {
            get
            {
                return _selectedClass;
            }
            set
            {
                _selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        public int ClassId
        {
            get
            {
                return _classId;
            }
            set 
            {
                _classId = value;
                OnPropertyChanged(nameof(ClassId));
            }
        }
        public ObservableCollection<Class> Classes
        {
            get
            {
                return _classes;
            }
            set
            {
                _classes = value;
                OnPropertyChanged(nameof(_classes));
            }

        }
        public ResultClassViewModel(int classId, NavigationState navState)
        {
            _navState = navState;
            _db = new DatabaseContext();
            _classId = classId;
            OnClassClickCommand = new RelayCommand(obj => { this.FetchAClass(); });
            OnBackNavCommand = new RelayCommand(obj => { this.navHomeView(); });
            FetchClasses();
        }
        private void FetchClasses()
        {
            Classes = new ObservableCollection<Class>(_db.FetchClasses(ClassId));
        }
        private void FetchAClass()
        {

            IsColumnVisible = true;
            if(SelectedClass != null)
            {
                SelectedStudentGroups = new ObservableCollection<StudentGroup>(SelectedClass.StudentGroups);
                Day = SelectedClass.Day.ToString();
                Start = SelectedClass.Start;
                End = SelectedClass.End;
                Room = SelectedClass.Room;
            }
           
        }
        public void navHomeView()
        {
            _navState.CurrentViewModel = new HomeViewModel(_navState);

        }
    }
}
