using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace App
{
    [Activity(Label = "App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.myListView);


            mItems = new List<string>();
            mItems.Add("Dynk");
            mItems.Add("Fabio");
            mItems.Add("Lucas");
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mItems);
            mListView.Adapter = adapter;
        }
    }
}

