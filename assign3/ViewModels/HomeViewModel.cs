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
using System.Data;
using System.Reflection;
using System.Windows;

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
        
        public ICommand SelectMeetingCommand { get; set; }
        public ICommand NavigateIntCommand { get; set; }
        private DataTable _itemSource;
        private ObservableCollection<Student> _students;


        public DataTable ItemSource
        {
            get
            {
                return _itemSource;
            }
            set
            {
                _itemSource = value;
                OnPropertyChanged(nameof(ItemSource));
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
            Option = "0";
            SelectStudentCommand = new RelayCommand(obj => { this.FetchStudents(); });
            SearchClassCommand = new RelayCommand(obj => { this.SearchClass(); });
            NavigateResultCommand = new RelayCommand(obj => { this.navResultView(); });
            SelectMeetingCommand = new RelayCommand(obj => { this.FetchMeeting(); });
            NavigateIntCommand = new RelayCommand(obj => { this.navIntView(); });
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
            ItemSource = ToDataTable<Student>(results);
        }

        public void navIntView()
        {
            _navState.CurrentViewModel = new InitialViewModel(_navState);
        }
        public void navResultView()
        {
            NavigationState state = new NavigationState();
            state = _navState;
            switch (Option)
            {
                case "0":
                    {
                        _navState.CurrentViewModel = new ResultMeetingViewModel(Int32.Parse(SearchValue));
                        break;
                    }
                    
                case "1":
                    if (checkClassInput(SearchValue))
                    {
                        _navState.CurrentViewModel = new ResultClassViewModel(Int32.Parse(SearchValue), _navState, this.GetType().Name);
                    }
                    else
                    {
                        MessageBox.Show("The text entered is: ");
                    }
                    
                    break;
            }
        }
        private bool checkClassInput(string input)
        {
            //for class input
            try 
            { 

                Int32.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void FetchMeeting()
        {
            List<Meeting> results = new List<Meeting>();
            results = _db.FetchAllMeetings();
            ItemSource = ToDataTable<Meeting>(results);
        }
        private DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);

                if (type.IsEnum)
                {
                    dataTable.Columns.Add(prop.Name, typeof(string));
                }
                else
                {
                    dataTable.Columns.Add(prop.Name, type);
                }
                //Setting column names as Property names
                
                
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    if (Props[i].PropertyType.IsEnum)
                    {
                        values[i] = Props[i].GetValue(item, null)?.ToString();
                    }
                    else
                    {
                        values[i] = Props[i].GetValue(item, null);
                    }
                    
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        //https://stackoverflow.com/questions/18100783/how-to-convert-a-list-into-data-table

        //https://www.youtube.com/watch?v=DM6Q7g7j7jc&list=PLA8ZIAm2I03ggP55JbLOrXl6puKw4rEb2&index=3
    }

}
