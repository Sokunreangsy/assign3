using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign3_con
{
    enum Campus 
    { 
        Hobart,
        Launceston
    }
    enum Category
    {
        Masters,
        Bachelors
    }
    class Student
    {
        public string StudentId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public int GroupId { get; set; }
        public string Title { get; set; }
        public Campus Campus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Category Category { get; set; }


        public override string ToString()
        {
            return String.Format("{0} {1}",GivenName,FamilyName);
        }


    }
}
