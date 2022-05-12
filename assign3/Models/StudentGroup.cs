using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3.Models
{
    /// <summary>
    /// model for studentGroup table
    /// </summary>
    public class StudentGroup
    {
        public int? GroupId { get; set; }
        public string GroupName { get; set; }

        public List<Student> StudentList { get; set; }

        public StudentGroup(){
            StudentList = new List<Student>();
        }
        public override string ToString()
        {
            return String.Format("{0} {1}", GroupId, GroupName);
        }
    }
}
