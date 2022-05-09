
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
namespace assign3.ViewModels
{
    class ResultClassViewModel : ViewModelBase
    {
        private ObservableCollection<Class> _classes ;

        public List<StudentGroup> StudentGroups { get; set; }

        private DatabaseContext _db;

        public ICommand OnClassClickCommand { get; set; }
        private bool _isColumnVisible;
        private Class _selectedClass;
        private int _classId;


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
        public ResultClassViewModel(int classId) 
        {
            _db = new DatabaseContext();
            _classId = classId;
            OnClassClickCommand = new RelayCommand(obj => { this.FetchAClass(); });
            FetchClasses();
        }
        private void FetchClasses()
        {
            Classes = new ObservableCollection<Class>(_db.FetchClasses(ClassId));
        }
        private void FetchAClass()
        {
            IsColumnVisible = true;
        }

    }
}
