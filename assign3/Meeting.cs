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
		Sunday
	}
	public class Meeting
	{
		public int MeetingID { get; set; }
		public int GroupID { get; set; }
		public MeetingDay day { get; set; }
		public string Start { get; set; }
		public string End { get; set; }
		public string Room { get; set; }
		public override string ToString()
		{
			
			//return String.Format("Meeting-{0} for Group-{1} on {2} starts from {3} to {4} in {5}", MeetingID, GroupID, day, Start, End, Room);
			return String.Format("Meeting-{0} for Group-{1} on {2}", MeetingID, GroupID,day);
			// check later 

		}



	}
}
