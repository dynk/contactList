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

namespace App.Resources.model
{
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public int celphone { get; set; }
        public string name { get; set; }
        public string email { get; set; }

    }
}