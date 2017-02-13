using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Android.Util;
using App.Resources.model;

namespace App.Resources.DataHelper
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Person.db"))) {

                    connection.CreateTable<Person>();
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public bool InsertIntoTablePerson(Person person)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Person.db")))
                {

                    connection.Insert(person);
                    return true;
                }

            }
            catch(SQLiteException ex)
            {
                Log.Info("errr", ex.Message);
                return false;
            }
        }

        public List<Person> selectTablePerson()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Person.db")))
                {

                    return connection.Query<Person>("SELECT * FROM Person ORDER BY NAME DESC");
                    
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }

        public bool deleteTablePerson(Person person)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Person.db")))
                {

                    connection.Delete(person);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("errr", ex.Message);
                return false;
            }
        }

        public bool selectQueryTablePerson(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Person.db")))
                {

                    connection.Query<Person>("SELECT * FROM Person Where Id=?", Id);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("errr", ex.Message);
                return false;
            }
        }

    }
}