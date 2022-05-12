using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3.Models
{
	public enum MeetingDay
	{
		Monday,
		Tuesday,
		Wendesday,
		Thursday,
		Friday,
		Saturday,
		Sunday,
		empty
	}
	public class Meeting
	{
		public int? MeetingID { get; set; }
        public int? GroupID { get; set; }
        public MeetingDay? day { get; set; }
		public string Start { get; set; }
		public string End { get; set; } 
		public string Room { get; set; } 
		public override string ToString()
		{
			
			return String.Format("{0} {1} {2} {3} {4} {5}", MeetingID, GroupID, day, Start, End, Room);
			//return String.Format("{0} {1} {2} ", MeetingID, GroupID,day.ToString());
			// check later 

		}



	}
}
