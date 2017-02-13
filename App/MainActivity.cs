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

            Person person = new Person();
                person.name = "Lucas Oliveira";
                person.email = "lucas.o.isa@hotmail.com";
                person.celphone = 10101010;
            db.InsertIntoTablePerson(person);

            mListView = FindViewById<ListView>(Resource.Id.myListView);

            b = FindViewById<Button>(Resource.Id.button1);
            b.Click += delegate { callPage(); };
            
            ArrayAdapter<Person> adapter = new ArrayAdapter<Person>(this, Android.Resource.Layout.SimpleListItem1, LoadData());
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

