﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using assign3.Models;

namespace assign3.Database
{
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

        private List<StudentGroup> FetchGroups(int id)
        {
            List<StudentGroup> studentGroups = new List<StudentGroup>();
            MySqlDataReader rdr = null;
            try
            {

                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from studentGroup where group_id=?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.
                    studentGroups.Add(new StudentGroup
                    {
                        
                        GroupId = rdr.GetInt32(0),
                        GroupName = rdr.GetString(1)
                    });
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
                    //Note that in your assignment you will need to inspect the *type* of the
                    //employee/researcher before deciding which kind of concrete class to create.
                     Class result = new Class { 
                        ClassId=rdr.GetInt32(0),
                        Day=ParseEnum<Days>(rdr.GetString(1)),
                        Start=rdr.GetString(2),
                        End=rdr.GetString(3),
                        Room=rdr.GetString(4)
                    };
                    result.StudentGroups.Add(new StudentGroup
                    {
                        GroupId = rdr.GetInt32(5),
                        GroupName = rdr.GetString(6)
                    });
                    resultClass.Add(result);
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
                    meetings.Add(new Meeting
                    {
                        MeetingID = rdr.GetInt32(0),
                        GroupID = rdr.GetInt32(1),
                        day = ParseEnum<MeetingDay>(rdr.GetString(2)),
                        /*Start = rdr.GetString(3),
                        End = rdr.GetDateTime(4),
                        Room = rdr.GetDouble(5)*/

                        /// fetch only time
                        ///https://www.tutorialsrack.com/articles/309/how-to-get-only-time-part-from-datetime-in-csharp
                    });

                } // end of whil
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
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
