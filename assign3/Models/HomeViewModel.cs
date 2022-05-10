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

using System.Data;
using System.Reflection;


namespace assign3.Models
{
    public class HomeViewModel:ViewModelBase
    {
        // navigation bar
        private readonly NavigationState _navState;

        public ViewModelBase CurrentViewModel { get; set; }
        private DatabaseContext _db;
        // meeting
        public ICommand SelectMeetingCommand { get; set; }
        public ICommand SearchMeetingCommand { get; set; }  //search all meeting for a student
        public ICommand NavigateResultCommand { get; set; }

        private ObservableCollection<Meeting> _meetings;
        public ObservableCollection<Meeting> Meetings
        {
            get { return _meetings; }
            set { _meetings = value; OnPropertyChanged(nameof(Meetings)); }

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
        } // end of searchvalue
        // dropdown menue
        private ObservableCollection<KeyValuePair<int, string>> _dropDownOptions = new ObservableCollection<KeyValuePair<int, string>> {
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
        // option
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
            SelectMeetingCommand = new RelayCommand(obj => { this.FetchMeeting(); });
            SearchMeetingCommand = new RelayCommand(obj => { this.SearchMeeting(); });
            NavigateResultCommand = new RelayCommand(obj => { this.navResultView(); });
            _db = new DatabaseContext();
        }

        private void FetchMeeting()
        {

            List<Meeting> results = new List<Meeting>();
            results = _db.FetchAllMeetings();
            Meetings = new ObservableCollection<Meeting>(results);

        }

        private void SearchMeeting() 
        {

            string test = SearchValue;        
        }

        public void navResultView()
        {
            switch (Option)
            {
                case "0":
                    _navState.CurrentViewModel = new ResultMeetingViewModel(Int32.Parse(SearchValue));
                    break;
            }
        }

        /*private void FetchMeeting()
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
        }*/







    }
}
