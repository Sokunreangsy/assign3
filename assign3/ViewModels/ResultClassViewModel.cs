
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assign3.Database;
using assign3.Models;
namespace assign3.ViewModels
{
    class ResultClassViewModel : ViewModelBase
    {
        private Class _aClass = new Class();

        public List<StudentGroup> StudentGroups { get; set; }

        private DatabaseContext _db;
        
        public string Start => _aClass.Start;
        public string End => _aClass.End;
        public string Room => _aClass.Room;


        private string _day;
        public string Day
        {
            get
            {
                return _aClass.Day.ToString();
            }
            set
            {
                _day = value;
                OnPropertyChanged(nameof(Day));
            }
        }
        public Class Aclass
        {
            get
            {
                return _aClass;
            }
            set
            {
                _aClass = value;
                OnPropertyChanged(nameof(Aclass));
            }

        }
        public ResultClassViewModel(int classId) 
        {
            _db = new DatabaseContext();
            _aClass.ClassId = classId;
            FetchAClass();
        }
        private void FetchAClass()
        {
            _aClass = _db.FetchAClass(_aClass.ClassId);
            
        }

    }
}
