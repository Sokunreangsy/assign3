using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using System.Collections.ObjectModel;
using System.Windows.Input;

using assign3.Models;
using assign3.Database;
using assign3.Command;
using System.Runtime.CompilerServices;

namespace assign3.Controllers
{
    public class MainViewController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
        public MainViewController()
        {
            //bind the "SelectStudentCommand" to select student lists
            SelectStudentCommand = new RelayCommand(obj => { this.FetchStudents(); });
            SearchClassCommand = new RelayCommand(obj => { this.SearchClass(); });
            _db = new DatabaseContext();
        }
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
/*public class SelectStudentsCommand : ICommand
{
    
    public event EventHandler CanExecuteChanged;

    private List<Student>
    public SelectStudentsCommand()
    public bool CanExecute(object parameter)
    {
        return true;
    }
    protected void OnCanExecutedChanged()
    {
        CanExecuteChanged.Invoke(this, new EventArgs());
    }

    public void Execute(object parameter)
    {
        
    }
}*/
//https://www.youtube.com/watch?v=2FPFgW0xVB0
//https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/commanding-overview?view=netframeworkdesktop-4.8
// https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern