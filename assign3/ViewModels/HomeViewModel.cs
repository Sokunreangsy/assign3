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

namespace assign3.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {



       
        private readonly NavigationState _navState; 
        public ViewModelBase CurrentViewModel { get; set; }
        private DatabaseContext _db;
        public ICommand SelectStudentCommand { get; set; }
        public ICommand SearchClassCommand { get; set; }
        public ICommand NavigateResultCommand { get; set; }

        private ObservableCollection<Student> _students;
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
        private string _searchValue;
        public string SearchValue
        {
            get
            {
                return _searchValue;
            }
            set
            {
                _searchValue = value;
                OnPropertyChanged(nameof(SearchValue));
            }
        }
        private ObservableCollection<KeyValuePair<int,string>> _dropDownOptions = new ObservableCollection<KeyValuePair<int, string>> {
            new KeyValuePair<int, string>(0,"Students"),
            new KeyValuePair<int, string>(1, "Classes"),
            new KeyValuePair<int, string>(2, "Meetings"),
            new KeyValuePair<int, string>(3, "Groups"),
            

        };
        public ObservableCollection<KeyValuePair<int, string>> DropDownOptions
        {
            get
            {
                return _dropDownOptions;
            }
            set
            {
                _dropDownOptions = value;
                OnPropertyChanged(nameof(DropDownOptions));
            }
        }
        private string _option;
        public string Option
        {
            get
            {
                return _option;
            }
            set
            {
                _option = value;
                OnPropertyChanged(nameof(Option));
            }
        }
        public HomeViewModel(NavigationState navState)
        {
            //bind the "SelectStudentCommand" to select student lists
            _navState = navState;
            SelectStudentCommand = new RelayCommand(obj => { this.FetchStudents(); });
            SearchClassCommand = new RelayCommand(obj => { this.SearchClass(); });
            NavigateResultCommand = new RelayCommand(obj => { this.navResultView(); });
            _db = new DatabaseContext();
        }
        private void SearchClass()
        {
            string test = SearchValue;
        }
        private void FetchStudents()
        {
            List<Student> results = new List<Student>();
            results = _db.FetchAllStudents();
            Students = new ObservableCollection<Student>(results);
        }
        public void navResultView()
        {
            switch (Option)
            {
                case "1":
                    _navState.CurrentViewModel = new ResultClassViewModel(Int32.Parse(SearchValue));
                    break;
            }
        }
        //https://www.youtube.com/watch?v=DM6Q7g7j7jc&list=PLA8ZIAm2I03ggP55JbLOrXl6puKw4rEb2&index=3
    }

}
