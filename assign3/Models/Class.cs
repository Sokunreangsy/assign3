using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3.Models
{
    public enum Days
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
        empty
    }
    public class Class
    {
        public int? ClassId { get; set; }
        public int? GroupId { get; set; }
        public Days? Day { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Room { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }

        public Class()
        {
            StudentGroups = new List<StudentGroup>();   
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}",Day.ToString(),Start,End,Room);
        }
    }
}
