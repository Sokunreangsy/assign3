using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3.Models
{
    /// <summary>
    /// model for student table
    /// </summary>
    public enum Campus 
    { 
        Hobart,
        Launceston
    }
    public enum Category
    {
        Masters,
        Bachelors
    }
    public class Student
    {
        public int? StudentId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        /*        public int GroupId { get; set; }
        public string Title { get; set; }
        public Campus Campus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Category Category { get; set; }*/
        public List<Meeting> MeetingsList { get; set; }
        public List<Class> ClassesList { get; set; }
        public Student()
        {
            MeetingsList = new List<Meeting>();
            ClassesList = new List<Class>();
        }
        public override string ToString()
        {
            return String.Format("{0} {1}",GivenName,FamilyName);
        }


    }
}
