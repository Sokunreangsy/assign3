using assign3.Command;
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
    class BachelorViewModel:ViewModelBase
    {
        public ICommand NavigateIntCommand { get; set; }
        public ICommand NavigateResultCommand { get; set; }
        private readonly NavigationState _navState;
        private readonly NavigationState _preNavState;

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

        public BachelorViewModel(NavigationState navState)
        {
            _navState = navState;
            Option = "0";
            NavigateIntCommand = new RelayCommand(obj => { this.navIntView(); });
            NavigateResultCommand = new RelayCommand(obj => { this.navResultView(); });
        }
        private ObservableCollection<KeyValuePair<int, string>> _dropDownOptions = new ObservableCollection<KeyValuePair<int, string>> {
            new KeyValuePair<int, string>(0,"Groups"),
            new KeyValuePair<int, string>(1, "Student Meetings"),
            new KeyValuePair<int, string>(2, "Classes"),
            new KeyValuePair<int, string>(3, "Student Classes"),


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
        private void navIntView()
        {
            _navState.CurrentViewModel = new InitialViewModel(_navState);
        }
        public void navResultView()
        {

            switch (Option)
            {

                case "0":
                    if (checkClassInput(SearchValue))
                    {
                        _navState.CurrentViewModel = new ResultGroupViewModel(Int32.Parse(SearchValue), _navState, this.GetType().Name);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input (numbers only)");
                    }

                    break;
                case "1":
                    {
                        if (checkClassInput(SearchValue))
                        {
                            _navState.CurrentViewModel = new ResultMeetingViewModel(Int32.Parse(SearchValue), _navState, this.GetType().Name);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Input (numbers only)");
                        }

                        break;
                    }
                case "2":
                    if (checkClassInput(SearchValue))
                    {
                        _navState.CurrentViewModel = new ResultClassViewModel(Int32.Parse(SearchValue), _navState, this.GetType().Name);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input (numbers only)");
                    }

                    break;

                case "3":
                    if (checkClassInput(SearchValue))
                    {
                        _navState.CurrentViewModel = new ResultStudentClassViewModel(Int32.Parse(SearchValue), _navState, this.GetType().Name);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input (numbers only)");
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
    }
}
