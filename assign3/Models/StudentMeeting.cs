using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3.Models
{
	class StudentMeeting
	{

		public int MeetingId { get; set; }

		public override string ToString()
		{
			return String.Format("MeetingID-{0}", MeetingId);
		}


	}
}
