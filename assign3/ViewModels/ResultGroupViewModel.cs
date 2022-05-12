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
using System.Windows;
using System.Windows.Input;

namespace assign3.ViewModels
{
    class ResultGroupViewModel : ViewModelBase
    {
        private NavigationState _navState;
        private string _preNavState;
        private StudentGroup _aGroup;
        private DatabaseContext _db;
        private ObservableCollection<Student> _students;
        private string _groupName;
        private int? _groupId;
        public ICommand OnBackCommand { get; set; }
        public StudentGroup AGroup
        {
            get
            {
                return _aGroup;
            }
            set
            {
                _aGroup = value;
                OnPropertyChanged(nameof(AGroup));
            }
        }
        public ObservableCollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
                OnPropertyChanged(nameof(GroupName));
            }
        }
        public int? GroupId
        {
            get
            {
                return _groupId;
            }
            set
            {
                _groupId = value;
                OnPropertyChanged(nameof(GroupId));
            }
        }
        public ResultGroupViewModel(int groupid, NavigationState navState, string preNavState)
        {
            _navState = navState;
            _preNavState = preNavState;
            OnBackCommand = new RelayCommand(obj => { this.navHomeView(); });
            _db = new DatabaseContext();
            fetchGroupId(groupid);
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
        public void fetchGroupId(int groupid)
        {
            AGroup = _db.FetchGroupStudents(groupid);
            Students = new ObservableCollection<Student>(AGroup.StudentList);
            GroupName = AGroup.GroupName;
            GroupId = AGroup.GroupId;
            if (Students.Count == 0)
            {
                MessageBox.Show("No result found");
            }
        }
    }
}
