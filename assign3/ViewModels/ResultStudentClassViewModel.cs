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
    class ResultStudentClassViewModel: ViewModelBase
    {
        private ObservableCollection<Class> _classes;
        private int? _studentId;
        private NavigationState _navState;
        private string _preNavState;
        private DatabaseContext _db;
        private Student _aStudent;
        public ICommand OnBackCommand { get; set; }

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

        public int? StudentId
        {
            get
            {
                return _studentId;
            }
            set
            {
                _studentId = value;
                OnPropertyChanged(nameof(StudentId));
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
                OnPropertyChanged(nameof(Classes));
            }
        }
        public ResultStudentClassViewModel(int studentid, NavigationState navState, string preNavState)
        {
            _navState = navState;
            _preNavState = preNavState;
            _db = new DatabaseContext();
            FetchClassesStudent(studentid);
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
        private void FetchClassesStudent(int id)
        {
            AStudent = _db.FetchClassStudents(id);
            Classes = new ObservableCollection<Class>(AStudent.ClassesList);
            _studentId = AStudent.StudentId;
 
        }
    }
}
