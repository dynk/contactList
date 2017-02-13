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
using App.Resources.DataHelper;
using App.Resources.model;

namespace App.Resources
{
    [Activity(Label = "Details")]
    public class Details : Activity
    {

        private TextView userTextView;
        public List<Person> personList;
        Database db;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            db = new Database();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Details);
            int id_user = Intent.GetIntExtra("id_user", 0);

            personList = db.selectQueryTablePerson(id_user);

            userTextView = FindViewById<TextView>(Resource.Id.txt_user_name);
            userTextView.Text = "Nome : " + personList[0].name;

            userTextView = FindViewById<TextView>(Resource.Id.txt_user_email);
            userTextView.Text = "Email : " + personList[0].email;

            userTextView = FindViewById<TextView>(Resource.Id.txt_user_phone);
            userTextView.Text = "Telefone : " + personList[0].celphone;

        }
    }
}