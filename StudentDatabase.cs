using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQ.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace SQ
{
    class StudentDatabase
    {

        public static string DBname = "SQLite.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBname);

        SQLiteConnection sqliteConnection;

        public StudentDatabase()
        {
            try
            {
                Console.WriteLine(DBPath);
                sqliteConnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Succefully Database Created!....");



            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }
        }

        public void StudentTable()
        {
            try
            {
                var created = sqliteConnection.CreateTable<Students>();
                Console.WriteLine("Succefully Table Created!....");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }

        }

        public bool InstertStudents(Students students)
        {


            long result = sqliteConnection.Insert(students);



            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Inserted Data ");
                return true;
            }


        }
        public bool UpdateStudents(Students students)
        {

            long result = sqliteConnection.Update(students);


            if (result == 1)
            {


                Console.WriteLine("Succefully Updated Data ");
                return true;
            }
            else
            {
                Console.WriteLine("Not any action perform ");
                return false;

            }


        }

        public bool DeleteStudents(Students students)
        {


            long result = sqliteConnection.Delete(students);
            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Deleted Data ");
                return true;
            }


        }

        public List<Students> ReadStudents()
        {
            try
            {
                var studentsDetails = sqliteConnection.Table<Students>().ToList();
                return studentsDetails;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                return null;
            }

        }

        public Students GetByUserId(int studentId)
        {
            var userId = sqliteConnection.Table<Students>().Where(u => u.sId == studentId).FirstOrDefault();

            return userId;

        }

        public Students GetByUserEnrollment(string studentEnr)
        {
            var user = sqliteConnection.Table<Students>().Where(u => u.sName == studentEnr).FirstOrDefault();

            return user;

        }
    }
}