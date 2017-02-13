﻿using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using App.Resources.model;
using App.Resources.DataHelper;
using App.Resources;
using static Android.Widget.AdapterView;

namespace App
{
    [Activity(Label = "App", MainLauncher = true, Icon = "@drawable/icon")]
   
    public class MainActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;
        private Button b;
        ListView lstData;
        List<Person> lstSource = new List<Person>();
        Database db;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            db = new Database();
            db.createDataBase();
            mListView = FindViewById<ListView>(Resource.Id.myListView);

            b = FindViewById<Button>(Resource.Id.button1);
            b.Click += delegate { callPage(); };

            ListViewAdapter myAdapter = new ListViewAdapter(this, LoadData());
            mListView.Adapter = myAdapter;

            mListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                int nameUser = (int) mListView.GetItemAtPosition(e.Position);
                Toast.MakeText(this, "" + nameUser, ToastLength.Short).Show();
            };

            

    }

        private List<Person> LoadData(){
                lstSource = db.selectTablePerson();
                return lstSource;
        }


        public void callPage() {
            var intent = new Intent(this, typeof(ContactActivity));
            StartActivity(intent);
        }

    }
}

