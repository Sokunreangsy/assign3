using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3.Models
{
    class StudentGroup
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }


        public override string ToString()
        {
            return String.Format("GroupId-{0}:{1}\n", GroupId, GroupName);
        }
    }
}
