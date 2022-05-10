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
		/*public DateTime Start { get; set; }
		public DateTime End { get; set; } 
		public double Room { get; set; } */
		public override string ToString()
		{
			
			//return String.Format("Meeting-{0} for Group-{1} on {2} starts from {3} to {4} in {5}", MeetingID, GroupID, day, Start, End, Room);
			return String.Format("{0} {1} {2}", MeetingID, GroupID,day.ToString());
			// check later 

		}



	}
}
