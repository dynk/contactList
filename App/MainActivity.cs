using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using App.Resources.model;
using App.Resources.DataHelper;
using App.Resources;

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

            mItems = new List<string>();
            mItems.Add("Dynk");
            mItems.Add("Fabio");
            mItems.Add("Lucas");
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            mListView.Adapter = adapter;



            //lstData.ItemClick += (s, e) => {
            //    for (int i = 0; i < lstData.Count; i++)
            //    {
            //        if(e.Position == i)
            //        {
            //            // vai pra pagina de edicao
            //        }
            //    }
                
            //};

            //LoadData();

            
        }

        //private void LoadData()
        //{
        //    lstSource = db.selectTablePerson();
        //    var adapter = new ListViewAdapter(this, lstSource);
        //    lstData.Adapter = adapter;
        //}

        public void callPage() {
            var intent = new Intent(this, typeof(ContactActivity));
            StartActivity(intent);
        }

    }
}

