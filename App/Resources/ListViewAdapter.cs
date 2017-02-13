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
using App.Resources.model;
using Java.Lang;

namespace App.Resources
{
    public class ViewHolder : Java.Lang.Object{
        public TextView txtName { get; set; }
        public TextView txtEmail { get; set; }
    }

    public class ListViewAdapter : BaseAdapter
    {

        private Activity activity;
        private List<Person> lstPerson;

        public ListViewAdapter(Activity activity, List<Person> lstPerson)
        {
            this.activity = activity;
            this.lstPerson = lstPerson;
        }

        public override int Count
        {
            get
            {
                return lstPerson.Count;
            }

        }
    
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstPerson[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ListViewAdapter, parent, false);

            var txtName = view.FindViewById<TextView>(Resource.Id.txt_username);
                txtName.Text = lstPerson[position].name;

            var txtEmail = view.FindViewById<TextView>(Resource.Id.txt_email);
                txtEmail.Text = lstPerson[position].email;

            return view;

        }
    }
}