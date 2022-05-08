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

namespace assign3.ViewModels
{
    public class HomeViewModel:ViewModelBase
    {
        private DatabaseContext _db;
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
        public HomeViewModel()
        {
            //bind the "SelectStudentCommand" to select student lists
            SelectStudentCommand = new RelayCommand(obj => { this.FetchStudents(); });
            SearchClassCommand = new RelayCommand(obj => { this.SearchClass(); });
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
        public ICommand SelectStudentCommand { get; set; }
        public ICommand SearchClassCommand { get; set; }
    }
   
}
