
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assign3.Database;
using assign3.Models;
namespace assign3.ViewModels
{
    class ResultClassViewModel : ViewModelBase
    {
        private ObservableCollection<Class> _classes ;

        public List<StudentGroup> StudentGroups { get; set; }

        private DatabaseContext _db;
        
        private int _classId;

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
            FetchAClass();
        }
        private void FetchAClass()
        {
            Classes = new ObservableCollection<Class>(_db.FetchClasses(ClassId));
        }

    }
}
