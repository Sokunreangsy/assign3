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
		//public DateTime MeetingTime { get; set; }
		public MeetingDay day { get; set; }
		
		public override string ToString()
		{
			
			return String.Format("Meeting-{0} for Group-{1} on {2}", MeetingID, GroupID, day);
			// check later
		}

		




	}
}
