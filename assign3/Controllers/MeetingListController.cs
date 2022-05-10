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
	public class MeetingListController : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ObservableCollection<Meeting> _meetings; 

		private DatabaseContext _db;
		public ObservableCollection<Meeting> Meetings
		{
			get { return _meetings; }
			set { _meetings = value; OnPropertyChanged(nameof(Meetings)); }

		}

		public MeetingListController()
		{
			
			SelectMeetingCommand = new RelayCommand(obj => { this.FetchMeeting(); });
			_db = new DatabaseContext();
		}


		protected void OnPropertyChanged(string name = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private void FetchMeeting()
		{
			List<Meeting> results = new List<Meeting>();
			results = _db.FetchAllMeetings();
			Meetings = new ObservableCollection<Meeting>(results);
		}
		public ICommand SelectMeetingCommand { get; set; } 


	}// end of public class MeetingListController
}
