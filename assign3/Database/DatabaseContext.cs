using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using assign3.Models;

namespace assign3.Database
{
    //class for database communications
    class DatabaseContext
    {
        private const string db = "gmis";
        private const string user = "gmis";
        private const string pass = "gmis";
        private const string server = "alacritas.cis.utas.edu.au";
        private static MySqlConnection conn = null;


        public DatabaseContext()
        {
            GetConnection();
        }
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public List<Student> FetchAllStudents()
        {
            List<Student> students = new List<Student>();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select given_name, family_name from student", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.
                    students.Add(new Student { GivenName = rdr.GetString(0), FamilyName = rdr.GetString(1) });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return students;
        }

        public List<StudentGroup> FetchGroups()
        {
            List<StudentGroup> studentGroups = new List<StudentGroup>();
            MySqlDataReader rdr = null;
            try
            {

                conn.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from studentGroup", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    StudentGroup group = new StudentGroup();
                    if (rdr.IsDBNull(1))
                    {
                        group.GroupId = null;
                    }
                    else
                    {
                        group.GroupId = rdr.GetInt32(0);
                    }
                    group.GroupName = rdr.GetString(1);
                    studentGroups.Add(group);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return studentGroups;
        }
        public List<Class> FetchAllClasses()
        {
            List<Class> resultClass = new List<Class>();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from class", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.
                    Class row = new Class();
                    if (rdr.IsDBNull(1))
                    {
                        row.GroupId = null;
                    }
                    else
                    {
                        row.GroupId = rdr.GetInt32(1);
                    }
                    row.ClassId = rdr.GetInt32(0);
                    row.Day = ParseEnum<Days>(rdr.GetString(2));
                    row.Start = rdr.GetString(3);
                    row.End = rdr.GetString(4);
                    row.Room = rdr.GetString(5);
                    
                    resultClass.Add(row);
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return resultClass;
        }
        public List<Class> FetchClasses(int id)
        {
            List<Class> resultClass = new List<Class>();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT class_id,day,class.start,class.end,room,studentGroup.group_id,studentGroup.group_name " +
                    "FROM class INNER JOIN studentGroup " +
                    "ON class.group_id=studentGroup.group_id " +
                    "WHERE class_id=?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Class row = new Class();
                    StudentGroup group = new StudentGroup();
                    if (rdr.IsDBNull(1))
                    {
                        group.GroupId = null;
                    }
                    else
                    {
                        group.GroupId = rdr.GetInt32(5);
                    }
                    row.ClassId = rdr.GetInt32(0);
                    row.Day = ParseEnum<Days>(rdr.GetString(1));
                    row.Start = rdr.GetString(2);
                    row.End = rdr.GetString(3);
                    row.Room = rdr.GetString(4);
                    group.GroupName = rdr.GetString(6);
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.

                    row.StudentGroups.Add(group);
                    resultClass.Add(row);
                }
                
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }              
            }

            return resultClass;
        }
        /*SELECT class_id,day,class.start,class.end,room FROM class 
        INNER JOIN studentGroup ON class.group_id=studentGroup.group_id
        WHERE class_id=2 */
        public List<Meeting> FetchAllMeetings()          //change to load all 
        {
            List<Meeting> meetings = new List<Meeting>();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from meeting", conn);
                //cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Meeting row = new Meeting();
                    if (rdr.IsDBNull(1))
                    {
                        row.GroupID = null;
                    }
                    else
                    {
                        row.GroupID = rdr?.GetInt32(1);
                    }
                    row.MeetingID = rdr?.GetInt32(0);
                    row.day = ParseEnum<MeetingDay>(rdr?.GetString(2));
                    row.Start = rdr?.GetString(3);
                    row.End = rdr?.GetString(4);
                    row.Room = rdr?.GetString(5);
                    meetings.Add(row);

                } // end of while
            } //end of try
            catch (MySqlException error)
            {
                Console.WriteLine("Error connecting to database: " + error);
            } // end of catch
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            } // end of finally
            return meetings;
        }
        public Student FetchStudentMeeting(int id)          //change to load all 
        {
            Student student = new Student();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT student.student_id,student.given_name,student.family_name,meeting.meeting_id,meeting.group_id,meeting.day,meeting.start,meeting.end,meeting.room " +
                    "FROM student " +
                    "INNER JOIN meeting " +
                    "ON student.group_id=meeting.group_id " +
                    "WHERE student.student_id=?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Meeting meeting = new Meeting();
                    
                    if (rdr.IsDBNull(4))
                    {
                        meeting.GroupID = null;
                    }
                    else
                    {
                        meeting.GroupID = rdr?.GetInt32(4);
                    }
                    student.StudentId = rdr?.GetInt32(0);
                    student.GivenName = rdr.GetString(1);
                    student.FamilyName = rdr?.GetString(2);

                    meeting.MeetingID = rdr?.GetInt32(3);
                    meeting.day = ParseEnum<MeetingDay>(rdr?.GetString(5));
                    meeting.Start = rdr?.GetString(6);
                    meeting.End = rdr?.GetString(7);
                    meeting.Room = rdr?.GetString(8);
                    student.MeetingsList.Add(meeting);
                } // end of while
            } //end of try
            catch (MySqlException error)
            {
                Console.WriteLine("Error connecting to database: " + error);
            } // end of catch
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            } // end of finally

            return student;
        }
        public StudentGroup FetchGroupStudents(int id)          //change to load all 
        {
            StudentGroup group = new StudentGroup();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT studentGroup.group_id,studentGroup.group_name," +
                    "student.student_id,student.given_name,student.family_name " +
                    "FROM studentGroup " +
                    "INNER JOIN student " +
                    "ON student.group_id=studentGroup.group_id " +
                    "WHERE studentGroup.group_id=?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();

                    group.GroupId = rdr?.GetInt32(0);
                    group.GroupName = rdr?.GetString(1);
                    student.StudentId = rdr?.GetInt32(2);
                    student.GivenName = rdr.GetString(3);
                    student.FamilyName = rdr?.GetString(4);

                    group.StudentList.Add(student);
                } // end of while
            } //end of try
            catch (MySqlException error)
            {
                Console.WriteLine("Error connecting to database: " + error);
            } // end of catch
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            } // end of finally

            return group;
        }
        public Student FetchClassStudents(int id)          //change to load all 
        {
            Student student = new Student();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT student.student_id," +
                    "class.class_id,class.group_id,class.day,class.start,class.end,class.room " +
                    "FROM student INNER JOIN class ON student.group_id=class.group_id " +
                    "WHERE student.student_id=?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Class aClass = new Class();

                    if (rdr.IsDBNull(2))
                    {
                        aClass.GroupId = null;
                    }
                    else
                    {
                        aClass.GroupId = rdr?.GetInt32(2);
                    }

                    student.StudentId = rdr?.GetInt32(0);
                    aClass.ClassId = rdr?.GetInt32(1);
                    aClass.Day = ParseEnum<Days>(rdr?.GetString(3));
                    aClass.Start = rdr?.GetString(4);
                    aClass.End = rdr?.GetString(5);
                    aClass.Room = rdr?.GetString(6);

                    student.ClassesList.Add(aClass);
                } // end of while
            } //end of try
            catch (MySqlException error)
            {
                Console.WriteLine("Error connecting to database: " + error);
            } // end of catch
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            } // end of finally

            return student;
        }
        private static T ParseEnum<T>(string value)
        {
            if (value =="")
            {
                return (T)Enum.Parse(typeof(T), "empty");
            }
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}