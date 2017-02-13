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
using App.Resources.DataHelper;

namespace App
{
    [Activity(Label = "ContactActivity")]
    public class ContactActivity : Activity
    {
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            db = new Database();
            base.OnCreate(savedInstanceState);
            
            // Create your application here
            SetContentView(Resource.Layout.addContact);

            var edtName = FindViewById<EditText>(Resource.Id.edtName);
            var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            var edtCellphone = FindViewById<EditText>(Resource.Id.edtCellphone);

            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);

            btnAdd.Click += delegate
            {
                Person person = new Person()
                {
                    name = edtName.Text,
                    email = edtEmail.Text,
                    celphone = int.Parse(edtCellphone.Text)
                };
                    if (db.InsertIntoTablePerson(person)) {
                        Toast.MakeText(this, "Contato : " + person.name + " Cadastrado com Sucesso !!", ToastLength.Long).Show();
                        var intent = new Intent(this, typeof(MainActivity));
                        StartActivity(intent);
                }; 
            };
        }
    }
}