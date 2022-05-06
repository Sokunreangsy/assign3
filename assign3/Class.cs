using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3_con
{
    enum Days
    {
        Monday,
        Tuesday,
        Wendesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    class Class
    {
        public int ClassId { get; set; }
        public int GroupId { get; set; }
        public Days Day { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Room { get; set; }
        public List<StudentGroup> StudentGroups { get; set; }

        public Class()
        {
            
        }

        public override string ToString()
        {
            string studentGroups = "\n";

            foreach (var group in StudentGroups)
            {
                studentGroups += group.ToString();
            }
            return String.Format("class-{0} on {1} {2}-{3} in room {4}{5}",ClassId,Day,Start,End,Room,studentGroups);
        }
    }
}
